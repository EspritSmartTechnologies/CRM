using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Category
    {
        [Key]
        public int IdProduct { get; set; }
        public string Label { get; set; }
    }
}
