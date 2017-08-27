using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vCard.Models
{
    public class Skill
    {
        [HiddenInput(DisplayValue = false)]
        public int SkillID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter name")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please, enter type")]
        public string Category { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Please, enter value")]
        [Range(0, 5, ErrorMessage = "Please, enter correct value between 0 and 5")]
        public int Value { get; set; }
    }
}