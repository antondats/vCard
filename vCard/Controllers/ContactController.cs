using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vCard.Infrastructure;
using vCard.Models;

namespace vCard.Controllers
{
    public class ContactController : Controller
    {
        private IContactProcessor contactProcessor;

        public ContactController(IContactProcessor cProcessor)
        {
            contactProcessor = cProcessor;
        }
        public ActionResult Index()
        {
            return View(new ContactInfo());
        }

        [HttpPost]
        public ActionResult Index(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                contactProcessor.SendMessage(contact);
                return View("Completed");
            }
            else
                return View(contact);
        }

    }
}