using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public enum Type {
        Mobile,
        Fixe
    }
    public class PointOfSale
    {
        [Key]
        public int IdPointOfSale { get; set; }
        public Type Type { get; set; }
        public List<Resources> Resources { get; set; }
        public List<Agents> Agents { get; set; }
    }
}
