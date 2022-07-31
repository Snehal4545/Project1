using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    [Table("Orders")]
    public class Order
    {

        [Key]
        public int Oid { get; set; }
        public int Id { get; set; }
        public int Uid { get; set; }
    }
}
