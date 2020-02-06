using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //lagt till 
using System.Linq;
using System.Threading.Tasks;




//Detta är datamodellen - underlag för att generera databasen. 
//Det är inte alltid att databasens begränsningar är identiska med begränsningar i systemet i övrigt, ex i ViewModels etc...



namespace MVCBasics.Models
{
    public class People
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(40)]
        public string PhoneNumber { get; set; }

        [StringLength(40)]
        public string City { get; set; }







        //public int Id  { get; set; }

        //public static List<People> peopleList = new List<People>();

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string PhoneNumber { get; set; }
        //public string City { get; set; }

        //public People()
        //{
        //    Id = ++idCounter;
        //}

    }
}


