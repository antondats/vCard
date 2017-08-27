using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vCard.Context;
using vCard.Models;

namespace vCard.Controllers
{
    public class PortfolioController : Controller
    {
        private IRepository repository;

        public PortfolioController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.Projects);
        }

        [ChildActionOnly]
        public string GetMainImage(int projectID)
        {
            Project project = repository.Projects.Where(p => p.ProjectID == projectID).FirstOrDefault();
            string path = "/Content/Images/Projects/" + project.Folder + "/main.jpg";
            return path;
        }
    }
}