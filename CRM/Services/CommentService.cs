using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Service.Pattern;
using Domain.Entities;
using Data;

namespace Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public CommentService() : base(utk)
        {
        }

        public List<Comment> GetCommentairesByPost(int id)
        {
            DBContext context = new DBContext();
            List<Comment> comments = factory.DataContext.Comments.Where(x => x.Post.IdPost == id).ToList();
            foreach (var x in comments) {

            }
            return GetMany(x => x.Post.IdPost == id).ToList();
        }
        //private List<Comment>GetChildren(List<Comment> comments, int id)
        //{

        //}
    }
}