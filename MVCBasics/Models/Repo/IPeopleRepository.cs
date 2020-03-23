using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models                   //.Repo tagit bort
{
    public interface IPeopleRepository
    {
        People Create(People people);

        bool Delete(People people);

        People Find(int id);

        bool Update(People people);


        List<People> All();

        //List<People> Contains();






        //19/3 allt nedan
       // bool Delete(int id);
        //bool UpdatePV(int id);


    }
}
