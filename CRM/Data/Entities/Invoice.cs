using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Invoice
    {
        [Key]
        public int IdInvoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Required]
        public  Payment Payment { get; set; }

    }
}
