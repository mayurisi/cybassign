using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidationDemo.Models
{
    //implementing self-validation in models
    public class Employee : IValidatableObject
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            //adding property level errors
            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Please enter name."));
            }

            if (string.IsNullOrWhiteSpace(JobTitle))
            {
                errors.Add(new ValidationResult("Please enter job title."));
            }         

            return errors;
        }
    }
}