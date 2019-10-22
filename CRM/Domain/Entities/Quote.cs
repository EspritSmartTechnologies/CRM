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
        public int IdQuote { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ValidDate { get; set; }
        [Required]
        public Payment Payment { get; set; }
        public string Content { get; set; }
    }
}
