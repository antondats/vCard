using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vCard.Context;
using vCard.Models;

namespace vCard.Controllers
{
    public class SkillsController : Controller
    {
        private IRepository repository;
        
        public SkillsController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            SkillsInfo info = new SkillsInfo();
            info.Skills = repository.Skills.ToList();
            info.Categories = repository.Skills.Select(s => s.Category).Distinct().ToList();
            return View(info);
        }
    }
}