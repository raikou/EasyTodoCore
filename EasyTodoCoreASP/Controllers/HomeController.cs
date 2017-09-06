﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyTodoCoreASP.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

	    public IActionResult TodoDetailView()
	    {
		    ViewData["Message"] = "Your application description page.";
		    return View();
	    }

		public IActionResult Error()
        {
            return View();
        }
    }
}
