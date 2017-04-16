using SerHumano.Common.Models.Persons;

namespace SerHumano.Common.Models.Security
{
    public class User
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
