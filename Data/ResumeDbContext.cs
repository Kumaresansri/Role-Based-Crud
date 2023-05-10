using Collection.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collection.Data
{
    public class ResumeDbContext: IdentityDbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {
        }
        public   DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicationUser>ApplicationUsers { get; set; } 
    }
}
