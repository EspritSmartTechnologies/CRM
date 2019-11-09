using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Response
    {
        [Key]
        public int IdResponse { get; set; }
        public DateTime ResponseDate { get; set; }
        public ApplicationUser User { get; set; }
        public string Content { get; set; }
    }
}
