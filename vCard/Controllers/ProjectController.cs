using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vCard.Context;
using vCard.Models;

namespace vCard.Controllers
{
    public class ProjectController : Controller
    {
        private IRepository repository;

        public ProjectController(IRepository repo)
        {
            repository = repo;
        }
        
        public ActionResult Item(int project)
        {
            Project result = repository.Projects.Where(pr => pr.ProjectID == project).FirstOrDefault();
            string path = @"C:\Users\Антон\Documents\Visual Studio 2015\Projects\vCard\vCard\Content\Images\Projects\" + result.Folder;
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] images = dir.GetFiles("*.jpg");
            ItemInfo itemInfo = new ItemInfo { Images = new List<string>()};
            foreach (FileInfo file in images)
                itemInfo.Images.Add(file.Name);
            itemInfo.Project = result;
            return View(itemInfo);
        }
    }
}