using Microsoft.EntityFrameworkCore;
using SerHumano.Common.Models.Persons;
using SerHumano.Common.Models.Security;
using SerHumano.Common.Services.Security;

namespace SerHumano.Repository
{
    public class SerHumanoContext: DbContext
    {
        public SerHumanoContext(DbContextOptions options ): base(options)
        {
        }

        public DbSet<Common.Models.Persons.Person> Persons{ get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccessToken> UserAccessTokens { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonType>().ToTable("PersonType");
            modelBuilder.Entity<Common.Models.Persons.Person>().ToTable("Person");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserAccessToken>().ToTable("UserAccessToken");
            modelBuilder.Entity<Access>().ToTable("Access");
            modelBuilder.Entity<Menu>().ToTable("Menu");
        }
    }
}