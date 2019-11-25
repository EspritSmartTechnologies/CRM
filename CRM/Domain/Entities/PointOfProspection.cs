using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PointOfProspection
    {
        [Key]
        public int IdPointOfProspection { get; set; }
        public Type Type { get; set; }
        public List<Resources> Resources { get; set; }
        public List<Agents> Agents { get; set; }
        public string name { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}
