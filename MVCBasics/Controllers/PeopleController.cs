using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasics.Models;         //Lagt till 
using Microsoft.AspNetCore.Mvc;  //Lagt till 


namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {
        [HttpGet]
        public IActionResult Index()  //denna skall vara en lista
        {
            return View(People.peopleList);
        }


        [HttpPost]

        public IActionResult Index(string filtervariabel)  /*inparameter är formens inputbariabel "filtervariabel" - måste vara lika*/
        {
            if (string.IsNullOrWhiteSpace(filtervariabel))
            {
                ViewBag.Msg = "Du måste ange en siffra!";
                return View(People.peopleList);               /* Fick error for each - la till peoplelist*/

            }

            return View(People.peopleList);
        }





        //Hämta sidan
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        //Posta/Spara formen 
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel) /*använder view model för att få in rätt värde */
        {
            if (ModelState.IsValid)
            {
                People.peopleList.Add(
                    new People()
                    {
                        Name = peopleViewModel.Name,
                        PhoneNumber = peopleViewModel.PhoneNumber,
                        City = peopleViewModel.City
                    });

                return RedirectToActionPermanent("Index");
            }
            return View(peopleViewModel);
        }




        ////Uffes del ej utvecklad - gör själv
        //public IActionResult Details()
        //{
        //    return View();
        //}

        ////Uffes del ej utvecklad
        //public IActionResult Remove()
        //{
        //    return View();
        //}
    }
}
