using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vCard.Models
{
    public class Project
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please, enter title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, enter description")]
        public string Description { get; set; }

        [Display(Name = "Path")]
        [Required(ErrorMessage = "Please, enter path to folder with images")]
        public string Folder { get; set; } 
    }
}