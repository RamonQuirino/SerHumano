using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SerHumano.Common.Models.Security;

namespace SerHumano.Common.Services.Security
{
    public class UserAccessToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime AuthenticateDate { get; set; }
        public DateTime LastAccesss { get; set; }
        public User User { get; set; }
    }
}
