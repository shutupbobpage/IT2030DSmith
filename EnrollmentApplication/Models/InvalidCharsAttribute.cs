using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string pattern = @"^[a-zA-Z0-9._-]+$";
        public InvalidCharsAttribute()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value != null)
            {              
                
                if (!(Regex.IsMatch(value.ToString(), pattern, RegexOptions.IgnoreCase)))
                {
                    return new ValidationResult("Notes contains unacceptable characters!");
                }
            }

            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}