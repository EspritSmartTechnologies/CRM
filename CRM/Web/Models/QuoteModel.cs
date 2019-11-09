using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    
    public class QuoteModel
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
        [StringLength(254)]
        public string description { get; set; }

    }
}