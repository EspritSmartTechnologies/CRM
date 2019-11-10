using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        public string Cat { get; set; }

        public List<Product> Products { get; set; }
    }
}
