using ModelValidationDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidationDemo.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        
        //using explicit validation
        public string Name { get; set; }
        
        //using metadata validation
        [Required(ErrorMessage="Please enter city")]
        public string City { get; set; }
        
        //using custom validation
        [DataType(DataType.Date)]
        [Required]
        [PastDate(ErrorMessage="Please enter date in the past")]
        //[Display(Name = "Birth Data")]       
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        //make it nullable to bypass default value type validation
        //public DateTime? DOB { get; set; }

        //using remote validation
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage="Email is mandatory field")]
        [Remote("IsUserEmailAvailable", "Customer", ErrorMessage="Email already exists!")]
        public string Email { get; set; }
    }
}