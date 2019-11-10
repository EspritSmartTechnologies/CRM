using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Comment
    {
        [Key]
        public int IdComment { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Parent { get; set; }
        public int? ParentId { get; set; }
        public List<React> Reacts { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
        public int? PostId { get; set; }
    }
}
