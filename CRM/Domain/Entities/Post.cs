using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<React> Reacts { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string Image { get; set; }



        

    }
}
