using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguro.Company.Web.Models
{
    public class ContactusModel
    {
        [Required(ErrorMessage="Please enter name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter email.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage="Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage="Please enter phone number.")]
        [Display(Name = "Phone")]
        [Phone(ErrorMessage="Please enter a valid phone number.")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage="Please enter enquiry subject.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage="Please enter eqnuiry details.")]
        [Display(Name = "Details")]
        public string Message { get; set; }
        
        public string Captcha { get; set; }
    }
}