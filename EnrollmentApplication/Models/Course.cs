using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        public virtual int CourseId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Exceeded maximum character length. (150)")]
        [Display(Name = "Course Title")]
        public virtual string CourseTitle { get; set; }

        [Display(Name = "Description")]
        public virtual string CourseDescription { get; set; }

        [Required]
        [Range(typeof(int), "1", "4", ErrorMessage = "Invalid entry. Value must be 1-4")]
        [Display(Name = "Number of credits")]
        public virtual int CourseCredits { get; set; }

    }
}