using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        //////////ForeignKey


        /////////////////
        [DataType(DataType.Date)]
        public DateTime Senddate { get; set; }

        public string nom { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }

        public string description { get; set; }

    }
}
