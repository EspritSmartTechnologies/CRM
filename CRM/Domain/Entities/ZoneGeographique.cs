using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class ZoneGeographique
    {
        public int Id { get; set; }
        public string pays { get; set; }
        public string gouvernorat { get; set; }
        public string ville { get; set; }


        public List<Promotion> promotions { get; set; }
    }
}
