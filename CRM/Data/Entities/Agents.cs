using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Agents
    {
        [Key]
        public int IdAgent { get; set; }
        public string FullName{ get; set; }
        public PointOfSale PointOfSale { get; set; }
    }
}
