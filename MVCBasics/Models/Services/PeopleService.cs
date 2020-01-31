using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models     /*.Services   -  ta bort detta sista ord*/
{
    public class PeopleService : IPeopleService    /*lägg till ": IPeopleService" och håll musen över - i ikonen som dyker upp välj generera servises*/
    {
        public People Create(string name, string phoneNumber, string city)
        {
            throw new NotImplementedException();
        }

        public People Filter(string filtervariabel)
        {
            throw new NotImplementedException();
        }
    }
}
