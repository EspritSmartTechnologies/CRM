using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    //class UserConfig : EntityTypeConfiguration<AspNetUser>
    //{
    //    public UserConfig()
    //    {
    //       HasMany(h => h.Posts)
    //          .WithRequired(b => b.User)
    //          .HasForeignKey(b => b.UserId)
    //          .WillCascadeOnDelete(true);
    //       HasMany(h => h.Comments)
    //          .WithRequired(b => b.User)
    //          .HasForeignKey(b => b.UserId)
    //          .WillCascadeOnDelete(true);
    //       HasMany(h => h.Reacts)
    //          .WithRequired(b => b.User)
    //          .HasForeignKey(b => b.UserId)
    //          .WillCascadeOnDelete(true);
    //    }
    //}

    class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            //modelBuilder.Entity<Post>()
            HasRequired(n => n.User)
            .WithMany(a => a.Posts)
            .HasForeignKey(n => n.UserId)
            .WillCascadeOnDelete(true);
        }
    }

    class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            //modelBuilder.Entity<Post>()
            HasRequired(n => n.User)
            .WithMany(a => a.Comments)
            .HasForeignKey(n => n.UserId)
            .WillCascadeOnDelete(true);

            HasRequired(n => n.Post)
            .WithMany(a => a.Comments)
            .HasForeignKey(n => n.PostId)
            .WillCascadeOnDelete(false);

            HasOptional(n => n.Parent)
            .WithMany(a => a.Comments)
            .HasForeignKey(n => n.ParentId)
            .WillCascadeOnDelete(false);
        }
    }

    class ReactConfig : EntityTypeConfiguration<React>
    {
        public ReactConfig()
        {
            //modelBuilder.Entity<Post>()
            HasRequired(n => n.User)
            .WithMany(a => a.Reacts)
            .HasForeignKey(n => n.UserId)
            .WillCascadeOnDelete(true);
        }
    }

    class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            //modelBuilder.Entity<Post>()
            HasRequired(n => n.Category)
            .WithMany(a => a.Products)
            .HasForeignKey(n => n.IdCategory)
            .WillCascadeOnDelete(false);
        }
    }
}
