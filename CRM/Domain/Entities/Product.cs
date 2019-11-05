using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {

        [Key]
        public int IdProduct { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public string IdCategory { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public PointOfSale PointOfSale { get; set; }
    }
}
