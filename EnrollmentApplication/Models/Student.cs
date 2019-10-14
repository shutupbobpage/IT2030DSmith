using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
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

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            //Validation 1 "Address1 can't equal Address2":

            if(Address1 == Address2)
            {
                yield return (new ValidationResult("Address2 cannot be the same as Address1."));
            }

            //Validation 2 "State must be two digits":

            if(State.Length != 2)
            {
                yield return (new ValidationResult("Enter a 2 digit State code."));
            }

            //Validation 3  "Zipcode must be 5 digits":

            if (Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Enter a 5 digit Zipcode."));
            }

            //throw new NotImplementedException();
        }
    }
}