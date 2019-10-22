using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public enum ReactType
    {
        Upvote,
        Downvote
    }
    public class React
    {
        [Key]
        public int IdReact { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public Comment Comments { get; set; }
        public ReactType Type { get; set; }
    }
}
