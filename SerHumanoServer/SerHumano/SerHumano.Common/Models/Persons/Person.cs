using System;

namespace SerHumano.Common.Models.Persons
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Cadastro { get; set; }
        public PersonType PersonType { get; set; }
    }
}
