using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SerHumano.Common.Models.Persons;

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
                    Id = 1,
                    Description = "Visitante"
                });
                context.PersonTypes.Add(new PersonType
                {
                    Id = 1,
                    Description = "Profissional"
                });
                context.PersonTypes.Add(new PersonType
                {
                    Id = 1,
                    Description = "Instituição"
                });
                context.PersonTypes.Add(new PersonType
                {
                    Id = 1,
                    Description = "Administrador"
                });
                context.SaveChanges();
            }
        }
    }
}
