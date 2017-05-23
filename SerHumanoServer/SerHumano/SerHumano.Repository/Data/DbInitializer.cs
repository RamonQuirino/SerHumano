using System;
using System.Linq;
using SerHumano.Common.Models.Persons;
using SerHumano.Common.Models.Security;

namespace SerHumano.Repository.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SerHumanoContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (!context.PersonTypes.Any())
            {
                context.PersonTypes.Add(new PersonType
                {                    
                    Description = "Visitante"
                });
                context.PersonTypes.Add(new PersonType
                {                 
                    Description = "Profissional"
                });
                context.PersonTypes.Add(new PersonType
                {                    
                    Description = "Instituição"
                });
                context.PersonTypes.Add(new PersonType
                {                   
                    Description = "Administrador"
                });
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Email= "ramon.ti@hotmail.com",
                    Password = "ram17zl",
                    Person = new Common.Models.Persons.Person
                    {
                        Cadastro = DateTime.Now,
                        Name = "Ramon Quirino da Silva",
                        PersonType = context.PersonTypes.First(x => x.Description == "Administrador")                       
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
