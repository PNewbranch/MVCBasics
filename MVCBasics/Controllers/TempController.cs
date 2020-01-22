using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  //för att kunna set och get för int och string i session
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;             //lagt till denna för att komma åt Models


namespace MVCBasics.Controllers
{
    public class TempController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



            //1. Här kontrollerar jag att alla värden är OK, att allt är på plats. Alltså att användaren MATAT IN EN INTEGER

            //2. När det är klart (exempelvis vi vet att vi har en siffra och inte en bokstav så kastar vi vidare siffran till 
            //MODELS/där skapar ny model (CLASS) med beräkningar som vars resultat retunderas tillbaka hit)            

            //3. Anv ev returvärdet till att ladda ny view



        [HttpPost]
        public IActionResult Index(string temp)
         {

            if (string.IsNullOrWhiteSpace(temp))
            {
                ViewBag.Msg = "Du måste ange en siffra!";
            }
            else
            {
                int newTemp = 0;
                try
                {
                    newTemp = Convert.ToInt32(temp);
                }
                catch
                {
                    ViewBag.Msg = "Ange en siffra!!!";
                    return View();
                }

                ViewBag.Msg = "Du angav " + newTemp + " grader som din temp. " + TempCheck.CheckTempInputFromUser(newTemp);
                
            }
                return View();
        }

    }

}