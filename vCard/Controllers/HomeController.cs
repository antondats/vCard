﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vCard.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Profile()
        {
            return View();
        }
    }
}