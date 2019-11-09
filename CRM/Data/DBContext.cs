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
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new Promo_ClientPromoConfig());
        }

        DbSet<Agents> Agents { get; set; }
        DbSet<Claim> Claims { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<PointOfSale> PointOfSales { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Quote> Quotes { get; set; }
        DbSet<React> Reacts { get; set; }
        DbSet<Resources> Resources { get; set; }
        DbSet<Response> Responses { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<PointOfProspection> PointOfProspections { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Satisfaction> Satisfactions { get; set; }
        //promotion
        public DbSet<Client> clients { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ZoneGeographique> Zones { get; set; }
        public DbSet<Client_Promotion> clients_promotions { get; set; }

    }

}
