using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public int IdPayment { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Quote Quote { get; set; }
        
        public Invoice Invoice { get; set; }
    }
}
