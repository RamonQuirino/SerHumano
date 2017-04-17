using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SerHumano.Common.Models.Persons;
using SerHumano.Common.Services.Security;

namespace SerHumano.Common.Models.Security
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<UserAccessToken> Tokens { get; set; }

    }
}
