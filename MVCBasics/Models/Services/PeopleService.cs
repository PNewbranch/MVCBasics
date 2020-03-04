using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models            //.Services  ta bort
{
    public class PeopleService : IPeopleService
    {

        //private static List<People> theList = new List<People>(); //Har ingen db/fil måste därför lägga det permanent i minnet (static)
        //private static int idCounter = 0;


        IPeopleRepository _peopleRepo;

        public PeopleService(IPeopleRepository peopleRepo)  //Dependency Injection
        {
            _peopleRepo = peopleRepo;
        }



        public People Create(string name, string phoneNumber, string city)
        {
            if (string.IsNullOrWhiteSpace(name)
                //|| string.IsNullOrWhiteSpace(phoneNumber)
                //|| string.IsNullOrWhiteSpace(city)
                )
            {
                return null;
            }

            People people = new People() { Name = name, PhoneNumber = phoneNumber, City = city };
            return _peopleRepo.Create(people);
        }
     


        public bool Remove(int id)
        {
            People people = Find(id);

            if (people != null)
            {
                return _peopleRepo.Remove(people);
            }

            return false;
        }



        public People Find(int id)
        {
            return _peopleRepo.Find(id);
        }



        public bool Update(People people)
        {
            if (people == null)
            {
                return false;
            }

            People currentPerson = Find(people.Id);

            if (currentPerson == null)
            {
                return false;
            }

            currentPerson.Name = people.Name;
            currentPerson.PhoneNumber = people.PhoneNumber;
            currentPerson.City = people.City;

            _peopleRepo.Update(currentPerson);

            return true;
        }





        public List<People> All()
        {
            return _peopleRepo.All();
        }
        



    }
}
