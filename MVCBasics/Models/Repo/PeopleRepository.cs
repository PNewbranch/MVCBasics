using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models            //.Repo
{
    public class PeopleRepository : IPeopleRepository
    {
        readonly ExDbContext _exDbContext;

        public PeopleRepository(ExDbContext exDbContext)
        {
            _exDbContext = exDbContext;
        }


//------------------------------------------------------------------------------------


        public People Create(People people)
        {
            _exDbContext.Peoples.Add(people);
            _exDbContext.SaveChanges();
            return people;
        }


        public bool Delete(People people)  //finns troligen en konvertering tidigare eftersom inte ID används
        {
            var result = _exDbContext.Peoples.Remove(people);
            _exDbContext.SaveChanges();
            return true;
        }


        public People Find(int id)   //behöv för att söka efter specifik person ner mot databasen
        {
            return _exDbContext.Peoples.SingleOrDefault(people => people.Id == id);
        }






        public bool Update(People people)
        {
            People peopleOrginal = Find(people.Id);

            if (peopleOrginal == null)
            {
                return false;
            }

            peopleOrginal = people;
            _exDbContext.SaveChanges();
            return true;
        }

               
        public List<People> All()
        {
            return _exDbContext.Peoples.ToList();
        }

        //public List<People> Contains()   
        //{
        //    return _exDbContext.Peoples.ToList();
        //}




       // //19/3 allt nedan
       //public bool Remove(int id);
       // bool Update(int id);





        //public bool Delete(int id)  //finns troligen en konvertering tidigare eftersom inte ID används
        //{

        //    var result = _exDbContext.Peoples.Remove(_exDbContext.Peoples.SingleOrDefault( p => p.Id == id));
        //    _exDbContext.SaveChanges();
        //    return true;
        //}





    }
}
