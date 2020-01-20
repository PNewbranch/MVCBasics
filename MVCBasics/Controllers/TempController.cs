using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  //för att kunna set och get för int och string i session
using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class TempController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Msg = HttpContext.Session.GetString("KeyName");
            return View();
        }

        [HttpPost]
        public IActionResult SaveTemp(string message)
        {

            //1. Här kontrollerar jag att alla värden är OK, att allt är på plats.

            //2. När det är klart (exempelvis vi vet att vi har en siffra och inte en bokstav så kastar vi vidare siffran till 
            //MODELS/där skapar ny model (CLASS) med beräkningar som vars resultat retunderas tillbaka hit)            

            //3. Anv ev returvärdet till att ladda ny view



            //if (string.IsNullOrWhiteSpace(info))
            //{
            //    ViewBag.Msg = "You must enter some text.";
            //    return View();
            //}
            //else
            //{
            //    Review.reviewsList.Add(new Review() { Info = info });

            //    return RedirectToAction("Index");
            //}


                                 
            HttpContext.Session.SetString("KeyName", message);

            

            return RedirectToAction("Index");
        }

    }

}