using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        //////ForeignKey
        //public int IdUser { get; set; }

        //[ForeignKey("IdUser")]
        //public User user { get; set; }

        ////////////////
        public DateTime InvoceDate { get; set; }

        ////ForeignKey
        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public Payment payment { get; set; }

    }
}
