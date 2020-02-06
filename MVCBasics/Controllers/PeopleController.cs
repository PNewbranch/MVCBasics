using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;  //Lagt till 
using MVCBasics.Models;         //Lagt till 


namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {

        //MÅSTE AVÄNDA DEPENDENCE INJECTION
        IPeopleService _peopleService; //spara som injectat

        public PeopleController(IPeopleService peopleService)  //Konstructor med dependence injection
        {
            _peopleService = peopleService;
        }

        //---------------------------------------------------------------------------
               

        [HttpGet]
        public IActionResult Index()  //denna skall vara en lista
        {
            return View(_peopleService.All()); //Serviceanrop
        }


        [HttpPost]
        public IActionResult Index(string filtervariabel)  /*inparameter är formens inputbariabel "filtervariabel" - måste vara lika*/
        {
            if (string.IsNullOrWhiteSpace(filtervariabel))
            {
                return View(_peopleService);            
            }
            else
            {
                return View(_peopleService.All());        //Anropa service visa alla

            }
        }





        //Hämta sidan
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        //Posta/Spara formen 
        [HttpPost]
        public IActionResult Create(PeopleViewModel people) /*använder view model för att få in rätt värde */
        {
            if (ModelState.IsValid)
            {
                _peopleService.Create(people.Name, people.PhoneNumber, people.City);

                return RedirectToAction("Index");
            }
            return View(people);
        }



    }
}
