using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonProfileTest4Project.Models
{
    public class PersonsProfileContext:DbContext
    {
        public PersonsProfileContext()
        {

        }
        public PersonsProfileContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PersonsProfile> personsprofiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonsProfile>();
        }
    }
}
