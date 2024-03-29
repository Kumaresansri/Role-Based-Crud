﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collection.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = "";
        [Required]
        [Range(1, 55, ErrorMessage = "Currently,We Have no Positions for your age")]
        [DisplayName("Age in Years")]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";
        [Required]
        [Range(1, 25, ErrorMessage = "Currently,We Have no Positions Vacant for Your Experience")]
        [DisplayName("Total Experience in Years")]
        public int TotalExperience { get; set; }
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "Please choose the Profile Photo")]
        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

    }
}
