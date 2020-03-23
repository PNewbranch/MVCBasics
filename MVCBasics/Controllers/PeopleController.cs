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
        IPeopleService _peopleService; //spara som injectat - uffe har denna som private readonly, why?

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


        //Full Lista och Filtrerad Lista använder samma INDEX
        [HttpPost]
        public IActionResult Index(string filtervariabel)  /*inparameter är formens inputbariabel "filtervariabel" - måste vara lika*/
        {
            if (string.IsNullOrWhiteSpace(filtervariabel))
            {
                return View(_peopleService.All());            
            }
            else
            {
                //Lägger över People-listan i en ny lista som gör så att inte kommandona inte krockar (Ulf hjälpte)
                List<People> theList = _peopleService.All();
                //Anv System.Linq - och LAMBDA => för att få en snabbare/enklare lösning - vi får fler och bättre "options"
                return View(theList.Where(person => person.City.Contains(filtervariabel)).ToList()); //använd filtervariabel för att filtrera 
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
            if (ModelState.IsValid) //ModelState används för att spåra/upptäcka fel/avvikelse kopplat till modellen
            {
                _peopleService.Create(people.Name, people.PhoneNumber, people.City);

                return RedirectToAction("Index");
            }
            return View(people);
        }


        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            People people = _peopleService.Find(id);

            if (people == null)
            {
                ViewBag.msg = "Kunden saknas.";
                return View("Index", _peopleService.All());
            }
            return View(people);
        }
        

        [HttpPost]
        public IActionResult Edit(People people) //Notera olika namn Edit här och Update i Services
        {
            if (ModelState.IsValid)
            {
                _peopleService.Update(people);  //CONTROLLERN använder EDIT i Services

                return RedirectToAction("Index");
            }
            return View(people);
        }



        [HttpGet]
        public IActionResult Delete(int id)   
        {
            bool result = _peopleService.Delete(id); //serviceinterfacet kallar på interface 

            if (result)
            {
                ViewBag.msg = "Kunden har raderats.";
            }
            else
            {
                ViewBag.msg = "Det gick inte att radera kunden, försök igen senare.";
            }
            return View("Index", _peopleService.All());
        }

 
       
               

        public IActionResult PeopleList() /*Visa hela listan med rader av PartialView*/
        {
            return View(_peopleService.All());  /*Controllern dirigerar till Service*/
        }


        public IActionResult PartialPeople(int id) /*Visar enskild rad*/
        {
            return PartialView("_PeoplePartial", _peopleService.Find(id));
        }





        //NEDAN TVÅ ÄR NYA SEDAN REMOVE-EDIT-KNAPPAR


        //public IActionResult RemovePV(int id) /*Visar enskild rad*/
        //{
        //    if (_peopleService.Remove(id))
        //    {
        //        return Content("was deleted"); //om lyckats skickas detta till javascriptfilen
        //    }
        //    else
        //    {
        //        return NotFound(); //alt om ej lyckas
        //    }

        //}



        //[HttpPost]
        //public IActionResult EditPV(int id) //Notera olika namn Edit här och Update i Services
        //{
        //    People people = _peopleService.Find(id);

        //    if (ModelState.IsValid)
        //    {

        //        _peopleService.Update(people);  //CONTROLLERN använder EDIT i Services

        //        return RedirectToAction("Index");
        //    }
        //    return View(people);
        //}



    }
}
