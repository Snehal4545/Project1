using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    [Table("Users")]
    public class Registration
    {       
        [Key]
        [ScaffoldColumn(false)]

        public int  Uid { get; set; }

        public string Name { get; set; }
        public string  EmailId { get; set; }
        public string Password { get; set; }

        [ScaffoldColumn(false)]

        public int RoleId { get; set; }

    }
}
