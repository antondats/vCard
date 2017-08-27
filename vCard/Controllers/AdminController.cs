using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vCard.Context;
using vCard.Models;

namespace vCard.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRepository repository;

        public AdminController(IRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Skills);
        }

        public ActionResult Projects()
        {
            return View(repository.Projects);
        }

        public ActionResult SkillEdit(int skillID)
        {
            Skill skill = repository.Skills.Where(s => s.SkillID == skillID).FirstOrDefault();
            return View(skill);
        }


        [HttpPost]
        public ActionResult SkillEdit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSkill(skill);
                TempData["message"] = string.Format("Changes of skill \"{0}\" was saved", skill.Name);
                return RedirectToAction("Index");
            }
            else { return View(skill); }
        }

        public ActionResult ProjectEdit(int projectID)
        {
            Project temp = repository.Projects.Where(p => p.ProjectID == projectID).FirstOrDefault();
            return View(temp);
        }

        [HttpPost]
        public ActionResult ProjectEdit(Project project)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProject(project);
                TempData["message"] = string.Format("Changes of project \"{0}\" was saved", project.Title);
                return RedirectToAction("Projects");
            }
            else return View(project);
        }

        public ActionResult AddSkill()
        {
            return View("SkillEdit", new Skill());
        }

        public ActionResult AddProject()
        {
            return View("ProjectEdit", new Project());
        }


        [HttpPost]
        public ActionResult DeleteSkill(int skillID)
        {
            Skill deletedSkill = repository.DeleteSkill(skillID);
            if (deletedSkill != null)
            {
                TempData["message"] = string.Format("Skill \"{0}\" was deleted",
                    deletedSkill.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteProject(int projectID)
        {
            Project deleted = repository.DeleteProject(projectID);
            if(deleted != null)
            {
                TempData["message"] = string.Format("Project \"{0}\" was deleted",
                    deleted.Title);
            }
            return RedirectToAction("Projects");
        }

    }
}