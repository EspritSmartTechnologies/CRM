using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Agents
    {
        [Key]
        public int IdAgent { get; set; }
        public string FullName{ get; set; }
        public PointOfProspection PointOfProspection { get; set; }
    }
}
