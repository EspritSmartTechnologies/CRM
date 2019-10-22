using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public User User { get; set; }
        public DateTime PostDate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<React> Reacts { get; set; }
        public string Content { get; set; }

    }
}
