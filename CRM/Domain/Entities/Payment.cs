using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        ///////// ForeignKey
        // public int IdUser { get; set; }

        // [ForeignKey("IdUser")]
        // public User user { get; set; }
        /////////////
        public DateTime payDate { get; set; }
        public float amountP { get; set; }


        ///////// ForeignKey
        public int QuoteId { get; set; }


        [ForeignKey("QuoteId")]
        public Quote quote { get; set; }
        ///////////
    }
}
