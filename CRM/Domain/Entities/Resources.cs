using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Resources
    {
        [Key]
        public int IdResource { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public PointOfSale PointOfSale { get; set; }
        public PointOfProspection pointOfProspection { get; set; }
    }
}
