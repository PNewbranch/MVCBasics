using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class GameCheck
    {

            //Models används för att göra med specifika konttroller och beräkningar - alltså EXEMPELVIS KONTROLLERANDE LOGIK

            public static string CheckGuessValue(int? random, int temp)
            {
                if (random < temp)
                {
                    return " Ditt nummer är FÖR HÖGT, försök igen!";
                }
                else if (random > temp)
                {
                    return " Ditt nummer är FÖR LÅGT, försök igen!";
                }
                else 
                {
                    return " Grattis du gissade rätt nummer - du är välkommen som KUND hos oss!";
                }
            }



    }
}
