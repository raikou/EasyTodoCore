﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyTodoCore2Asp.Models;

namespace EasyTodoCore2Asp.Controllers
{
    public class HomeController : Controller
    {
	    CoreContext.todo_dataModel context = new CoreContext.todo_dataModel();

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}