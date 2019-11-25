using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public enum Level
    {
        Non,
        Peu,
        Satisfait,
        Très,
    }
    public class Satisfaction
    {
        [Key]
        public int IdSatisfaction { get; set; }
        public ApplicationUser User { get; set; }
        public string idUser { get; set; }
        public Level Level { get; set; }
        public Claim Claim { get; set; }
        public int IdClaim { get; set; }

    }
}
