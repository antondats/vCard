using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vCard.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Enter your name, please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your e-mail, please")]
        [RegularExpression(@"(?i)^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Enter correct e-mail, please")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your message, please")]
        public string Message { get; set; }

    }
}