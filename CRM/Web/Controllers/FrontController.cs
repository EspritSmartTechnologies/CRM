﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        public ActionResult Index()
        {
            return View();
        }
    }
}