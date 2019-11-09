using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int num_tel { get; set; }
        public string Adress { get; set; }

        public List<Client_Promotion> CP { get; set; }
        public int nombre_carte_rechange { get; set; }
    }
}
