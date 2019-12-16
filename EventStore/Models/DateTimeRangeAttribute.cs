using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class DateTimeRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;            
            if (DateTime.Now.CompareTo(value) <= 0 && DateTime.Now.AddYears(5).CompareTo(value) >= 0)
            {
                return ValidationResult.Success;
            }
            else if (DateTime.Now.CompareTo(value) <= 0)
            {
                return new ValidationResult("Date cannot be more than 5 years in the future.");
            }
            else
            {
                return new ValidationResult("Date cannot be in the past.");
            }
        }
    }
}