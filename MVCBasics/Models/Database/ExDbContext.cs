using Microsoft.EntityFrameworkCore;  //lagt till 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models         //.Database tagit bort
{
    public class ExDbContext : DbContext
    {

        public ExDbContext(DbContextOptions<ExDbContext> options) : base(options)
        { }
        public DbSet<People> Peoples { get; set; }  //regelverk över det som skall skapas 




        //här sätter man även tabellrelateioner 1:1  1:m etc  - detta kan jag behöva skapa
               
        //här sätts egna nycklar (default skapas per automatik shaddowkey) - men - detta BEHÖVS INTE (kan ställa istället ställa till problem)
       
        //var skapar man Index? görs detta överhuvudtaget?




    }
}
