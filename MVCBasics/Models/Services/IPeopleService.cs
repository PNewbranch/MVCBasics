using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models            //.Services ta bort
{
    public interface IPeopleService   /*1. SKAPA INTERFACE VIA ADD/NEW ITEM/INTERFACE*/
    {                                 /*lägg till ": IPeopleService" och håll musen över - i ikonen som dyker upp välj generera servises*/
        
       
        
        People Create(string name, string phoneNumber, string city);        /*2. LÄGG TILL ALLA SERVICES I INTERFACET*/
        
        bool Delete(int id);  //boolean, används enligt "lyckades jag ta bort"?

        People Find(int id);

        bool Update(People people);


               
        List<People> All();

        //List<People> Contains(string filtervariabel);


        //bool RemovePV(int id);

    }
}
