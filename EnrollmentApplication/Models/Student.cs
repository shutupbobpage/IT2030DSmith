using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student
    {

        public virtual int StudentId { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Exceeded maximum character length. (max = 50)")]
        [Display(Name = "First Name")]

        public virtual string StudentLastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exceeded maximum character length.(max = 50)")]
        [Display(Name = "Last Name")]
        public virtual string StudentFirstName { get; set; }
    }
}