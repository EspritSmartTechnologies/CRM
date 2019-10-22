using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Data.Entities
{
    public enum Types
    {
        Technique,
        Financièr,
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
        public Type Type { get; set; }
        public State State { get; set; }
        public DateTime Date { get; set; }
        public List<Response> Responses { get; set; }
        public User User { get; set; }

    }
}
