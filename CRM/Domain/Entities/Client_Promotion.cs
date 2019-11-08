using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Client_Promotion
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client client { get; set; }

        public int PromotionId { get; set; }
        [ForeignKey("PromotionId")]
        public Promotion promotion { get; set; }
    }
}
