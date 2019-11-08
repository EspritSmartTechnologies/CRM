using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Periode
    {
        public int id { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime date_deb { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]

        public DateTime date_fin { get; set; }
        public string saison { get; set; }

        public List<Promotion> promotions { get; set; }
    }
}
