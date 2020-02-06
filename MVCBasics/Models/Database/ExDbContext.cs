using Microsoft.EntityFrameworkCore;  //lagt till 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models         //.Database tagit bort
{
    public class ExDbContext: DbContext
    {

        public ExDbContext(DbContextOptions<ExDbContext> options) : base(options)
        { }
        public DbSet<People> Peoples { get; set; }

    }
}
