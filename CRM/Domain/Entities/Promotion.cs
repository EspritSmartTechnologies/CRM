using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Entities
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Description { get; set; }


        public string nom { get; set; }

        public int periode_Id { get; set; }
        [ForeignKey("periode_Id")]
        public Periode periode { get; set; }
        public int Zone_Id { get; set; }
        [ForeignKey("Zone_Id")]
        public ZoneGeographique zone { get; set; }
        public List<Product> produits { get; set; }
        public List<Client_Promotion> CP { get; set; }


        public string ImageURL { get; set; }

        //[DisplayName("Upload Image")]
        //public string ImagePath { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
    }
}
