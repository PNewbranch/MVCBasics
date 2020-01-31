using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models             /*.Services   -  ta bort detta sista ord*/
{
    public interface IPeopleService         /*INTERFACE SKAPAS FÖRST MED ALLA FUNKTIONER/METODER - DÄREFTER AUTOMATGENERERAS SERVISES*/
    {                                                                       /*1. SKAPA INTERFACE VIA ADD/NEW ITEM/INTERFACE*/
        People Create(string name, string phoneNumber, string city);        /*2. LÄGG TILL ALLA SERVICES I INTERFACET*/

        People Filter(string filtervariabel);
    }
}


            //3. SKAPA SERVICES VIA ADD/NEW CLASS 
            //4. I nya servicen - lägg till ": IPeopleService" och håll musen över - i ikonen som dyker upp välj "generera services"

