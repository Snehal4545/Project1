using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    [Table("Cart")]
    
    public class Cart
    {
        [Key]
        
        public int Cid { get; set; }
        public int Uid { get; set; }
        public int Id { get; set; }

    }
}
