using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Data.Configurations;

namespace Data
{
    public class DBContext : DbContext

    {

        public DBContext():base("MyContext")
        {

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

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new Promo_ClientPromoConfig());

           

        }



    }

}
