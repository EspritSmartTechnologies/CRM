using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Post Post { get; set; }
        public int? IdPost { get; set; }
        public Comment Comment { get; set; }
        public int? IdCommentaire { get; set; }
        public ReactType Type { get; set; }
    }
}
