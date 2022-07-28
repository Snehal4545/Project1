using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company  { get; set; }
        public int Price { get; set; }
    }
}
