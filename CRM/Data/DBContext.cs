using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain;
using Data.Configurations;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DBContext")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class DBContext : ApplicationDbContext

    {

        public DBContext() 
        {
            
        }
        

        public DbSet<Agents> Agents { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PointOfSale> PointOfSales { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<PointOfProspection> PointOfProspections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Satisfaction> Satisfactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PostConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new ReactConfig());
        }

    }

}
