using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;     //Lägg till - you can control validation of the models from views based on the ViewModel
using System.Linq;
using System.Threading.Tasks;



namespace MVCBasics.Models
{
    public class PeopleViewModel
    {

        [Required]
        [Display(Name = "Namn")]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Telefonnummer")]
        [StringLength(40)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hemort")]
        [StringLength(40)]
        public string City { get; set; }


        //Lägg till det vi behöver i vyn - ex knappar skapa radera editera filtrera



        //19/3 allt nedan
        public PeopleViewModel() {} //zero constuctor(inga inparametrar)

        public PeopleViewModel(People people)
        {
            Name = people.Name;
            PhoneNumber = people.PhoneNumber;
            City = people.City;
        }

    }
       
}


