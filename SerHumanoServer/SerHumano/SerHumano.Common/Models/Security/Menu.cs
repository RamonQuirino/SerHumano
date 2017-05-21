using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerHumano.Common.Models.Security
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }
        public Access Access { get; set; }
        public Menu ParentMenu { get; set; }
        public bool IsLink { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}
