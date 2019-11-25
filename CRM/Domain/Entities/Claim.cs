using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Domain.Entities
{
    public enum Types
    {
        Technique,
        Financière,
        Relationnelle
    }
    public enum State
    {
        Ouverte,
        EnCours,
        Traitée,
        Fermée
    }

    public class Claim
    {
        [Key]
        public int IdClaim { get; set; }
        public Types Type { get; set; }
        public State State { get; set; }
        public DateTime Date { get; set; }
        public List<Response> Responses { get; set; }
        public List<Satisfaction> Satisfactions { get; set; }
        public ApplicationUser User { get; set; }
        public string userId { get; set; }
        public string Content { get; set; }

    }
}
