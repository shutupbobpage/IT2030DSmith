using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentID { get; set; }
        public virtual int StudentID { get; set; }

        [Display(Name = "Course ID")]
        public virtual int CourseID { get; set; }

        //[Required]
        [RegularExpression(@"[A-F]", ErrorMessage = "Please enter a valid grade.")]
        public virtual string Grade { get; set; }
        public virtual bool IsActive { get; set; }

        [Required(ErrorMessage = "Assigned campus is required.")]
        [Display(Name = "Campus")]
        public virtual string AssignedCampus { get; set; }

        [Required(ErrorMessage = "Enrollment semester is required.")]
        [Display(Name = "Enrolled in Semster")]
        public virtual string EnrollmentSemester { get; set; }

        [Required(ErrorMessage = "Enrollment year is required.")]
        [Range(typeof(int), "2018", "2020", ErrorMessage = "Please enter a valid enrollment year.")]
        [Display(Name = "Enrollment Year")]
        public virtual int EnrollmentYear { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        [InvalidCharsAttribute]
        public virtual string Notes { get; set; }
        

    }
}