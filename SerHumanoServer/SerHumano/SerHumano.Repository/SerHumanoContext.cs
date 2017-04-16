using Microsoft.EntityFrameworkCore;
using SerHumano.Common.Models.Persons;
using SerHumano.Common.Models.Security;

namespace SerHumano.Repository
{
    public class SerHumanoContext: DbContext
    {
        public SerHumanoContext(DbContextOptions options ): base(options)
        {
        }

        public DbSet<Person> Persons{ get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonType>().ToTable("PersonType");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<User>().ToTable("User");            
        }
    }
}
