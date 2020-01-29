using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Lägg till 
using System.ComponentModel.DataAnnotations;


namespace MVCBasics.Models
{
    public class PeopleViewModel
    {

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string City { get; set; }


    }
}
