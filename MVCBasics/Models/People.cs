using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class People
    {
        static int idCounter = 0;

        public static List<People> peopleList = new List<People>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public People()
        {
            Id = ++idCounter;
        }

    }
}


