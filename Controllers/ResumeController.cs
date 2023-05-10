using Collection.Data;
using Collection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collection.Controllers
{
   
    public class ResumeController : Controller
    {
        private readonly ResumeDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public ResumeController (ResumeDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost; 
        }
        [Authorize(Roles = "Admin,sales")]
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants =_context.Applicants.ToList();
            return View(applicants);
        }
        [Authorize(Roles = "Admin,sales")]
        [HttpGet]
      
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
           
            return View(applicant);
        }
        [Authorize(Roles = "Admin,sales")]
        [HttpPost]
   
        public IActionResult Create(Applicant applicant)
        {
          


            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;


            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;
            if (applicant.ProfilePhoto != null)
           {
               string uploadsFloder = Path.Combine(_webHost.WebRootPath, "images");
               uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
               string filePath = Path.Combine(uploadsFloder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [Authorize(Roles = "Admin,sales")]
        public IActionResult Details(int Id)
        {
            Applicant applicant = _context.Applicants
                .Where(a => a.Id == Id).FirstOrDefault();

            return View(applicant);
        }
        [Authorize(Roles = "Admin,sales")]
        [HttpGet]
      
        public IActionResult Delete(int Id)
        {
            Applicant applicant = _context.Applicants
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(applicant);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
    
        public IActionResult Delete(Applicant applicant)
        {
            _context.Attach(applicant);
            _context.Entry(applicant).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,sales")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Applicant applicant = _context.Applicants
              
                .Where(a => a.Id == id).FirstOrDefault();
            return View(applicant);
        }
        [Authorize(Roles = "Admin,sales")]
        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
 
            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;
            _context.Update(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
