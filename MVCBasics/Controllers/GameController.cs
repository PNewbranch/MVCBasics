using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models; //lagt till för att nå models
using Microsoft.AspNetCore.Http; //lagt till i samband med Sessions


namespace MVCBasics.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            // skapa slump nummer och spara i session
            Random randomNo = new Random();
            int correctValue = randomNo.Next(1, 100);

            //Förbereder - skapar en hylla döpt "random" som innehåller det slumpgenererade nummret i correctValue
            //värdet sparas så länge som tiden är satt i AddSession i Startup.cs 
            HttpContext.Session.SetInt32("random", correctValue);



            //ytterligare ett sessionsvärde, antal gissningar
            int noOfGuesses = 0;
            HttpContext.Session.SetInt32("noOfGuesses", noOfGuesses);

            return View();
        }

        [HttpPost]
        public IActionResult Index(string temp)
        {

            if (string.IsNullOrWhiteSpace(temp))
            {
                ViewBag.Msg = "Du måste ange en siffra mellan 1-100!";
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
                    ViewBag.Msg = "Ange en siffra mellan 1-100!!!";
                }

                if (newTemp < 1 || newTemp > 100)
                {
                    ViewBag.Msg = "Värdet MÅSTE vara en siffra mellan 1-100!!!";
                }


                // hämta EFTERSÖKT från session
                //session kan ibland retunera "null" (värde tappat pga att ex 30 min session gått ut) vilket inte är tillåtet i int - därav att vi nåste använda int?
                //fick även ändra i modellen så att jag hade int? som inparameter där med
                int? randomFromSession = HttpContext.Session.GetInt32("random");                  

                //hämta RÄKNARE-GISSNINGAR
                int? noOfGuesses = HttpContext.Session.GetInt32("noOfGuesses");
                if (HttpContext.Session.GetInt32("noOfGuesses") == 7)
                {
                    ViewBag.Msg = "Du har haft dina 7 gissningar! Gör en ny TempKoll (följ instruktionerna).";
                  }
                else if (HttpContext.Session.GetInt32("noOfGuesses") == null)
                {
                    ViewBag.Msg = "Du har varit inaktiv alldeles för länge, vänligen börja om.";
                }
                else
                {
                    //anrop till min modell där huvudlogiken ligger
                    ViewBag.Msg = "Du gissade på " + newTemp + "." + GameCheck.CheckGuessValue(randomFromSession, newTemp);

                    //räkna upp antl gissningar 
                    noOfGuesses = noOfGuesses + 1;
                    int numberOfGuesses = (int) noOfGuesses; /*konvertera-typecasta från int? till int*/
                    //uppdatera sessionsvärdet
                    HttpContext.Session.SetInt32("noOfGuesses", numberOfGuesses);

                }

            }
            return View();
        }

    }
}