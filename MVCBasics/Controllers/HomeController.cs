﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //HÄR ROUTAR VI TILL VÅRA MIDDLEVARE/VIEWERS
        //här läggs Views till - vilka skall återfinnas i under katalog Views/Home/ där de skall ligga som egna "cshtml-filer"
        //varje view fil där skall ha en IActionResult här - man skriver namnet som .cshtml-filen har och högerklickar på namnet "Company" och väljer "Add view"
        //nya viewerna skall dyka upp som sub-objekt under "HomeController"


        public IActionResult Forsale() 
        {
            return View();
        }

        public IActionResult Sold()
        {
            return View();
        }
        
        public IActionResult MathTable()
        {
            return View();
        }

    }

}