using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class TempCheck
    {

        //Models används för att göra med specifika konttroller och beräkningar - alltså EXEMPELVIS KONTROLLERANDE LOGIK

        public static string CheckTempInputFromUser (int Temp)
        {
            if (Temp > 37)
            {
                return "Du har en feber (över 37 grader) - du är således HET NOG!";
            }
            else if (Temp < 37)
            {
                return "Dessvärre är du lite för sval (under 37 grader) för att ingå i vår kundkrets!";
            }
            else
            {
                return "Du är normalvarm (37 grader) - vänligen kvalificera dig som kund genom testet 'Guessing Game'.";
            }
        }

    }
}
