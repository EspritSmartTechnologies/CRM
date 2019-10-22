using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Data
{
    class DBContext : DbContext

    {
        

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
    }

}
