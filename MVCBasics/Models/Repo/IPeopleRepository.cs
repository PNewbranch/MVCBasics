using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models                   //.Repo tagit bort
{
    public interface IPeopleRepository
    {
        People Create(People people);

        bool Remove(People people);

        People Find(int id);

        bool Update(People people);




        List<People> All();

        //List<People> Contains();
    }
}
