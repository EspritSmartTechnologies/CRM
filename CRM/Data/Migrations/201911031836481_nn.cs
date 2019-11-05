namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        IdAgent = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PointOfProspection_IdPointOfProspection = c.Int(),
                        PointOfSale_IdPointOfSale = c.Int(),
                    })
                .PrimaryKey(t => t.IdAgent)
                .ForeignKey("dbo.PointOfProspections", t => t.PointOfProspection_IdPointOfProspection)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_IdPointOfSale)
                .Index(t => t.PointOfProspection_IdPointOfProspection)
                .Index(t => t.PointOfSale_IdPointOfSale);
            
            CreateTable(
                "dbo.PointOfProspections",
                c => new
                    {
                        IdPointOfProspection = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPointOfProspection);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        IdResource = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(),
                        pointOfProspection_IdPointOfProspection = c.Int(),
                        PointOfSale_IdPointOfSale = c.Int(),
                    })
                .PrimaryKey(t => t.IdResource)
                .ForeignKey("dbo.PointOfProspections", t => t.pointOfProspection_IdPointOfProspection)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_IdPointOfSale)
                .Index(t => t.pointOfProspection_IdPointOfProspection)
                .Index(t => t.PointOfSale_IdPointOfSale);
            
            CreateTable(
                "dbo.PointOfSales",
                c => new
                    {
                        IdPointOfSale = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Adress = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPointOfSale);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        Cat = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        IdClaim = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdClaim)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        IdResponse = c.Int(nullable: false, identity: true),
                        ResponseDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_IdUser = c.Int(),
                        Claim_IdClaim = c.Int(),
                    })
                .PrimaryKey(t => t.IdResponse)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .ForeignKey("dbo.Claims", t => t.Claim_IdClaim)
                .Index(t => t.User_IdUser)
                .Index(t => t.Claim_IdClaim);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Comment_IdComment = c.Int(),
                        Post_IdPost = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Comments", t => t.Comment_IdComment)
                .ForeignKey("dbo.Posts", t => t.Post_IdPost)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.Comment_IdComment)
                .Index(t => t.Post_IdPost)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdPost)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        IdReact = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Comments_IdComment = c.Int(),
                        Post_IdPost = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdReact)
                .ForeignKey("dbo.Comments", t => t.Comments_IdComment)
                .ForeignKey("dbo.Posts", t => t.Post_IdPost)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.Comments_IdComment)
                .Index(t => t.Post_IdPost)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        IdInvoice = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdInvoice)
                .ForeignKey("dbo.Payments", t => t.IdInvoice)
                .Index(t => t.IdInvoice);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        IdPayment = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPayment);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        IdQuote = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        ValidDate = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.IdQuote)
                .ForeignKey("dbo.Payments", t => t.IdQuote)
                .Index(t => t.IdQuote);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Colour = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_IdCategory = c.Int(),
                        PointOfSale_IdPointOfSale = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Categories", t => t.Category_IdCategory)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_IdPointOfSale)
                .Index(t => t.Category_IdCategory)
                .Index(t => t.PointOfSale_IdPointOfSale);
            
            CreateTable(
                "dbo.Satisfactions",
                c => new
                    {
                        IdSatisfaction = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Claim_IdClaim = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdSatisfaction)
                .ForeignKey("dbo.Claims", t => t.Claim_IdClaim)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.Claim_IdClaim)
                .Index(t => t.User_IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Satisfactions", "Claim_IdClaim", "dbo.Claims");
            DropForeignKey("dbo.Products", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Products", "Category_IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Invoices", "IdInvoice", "dbo.Payments");
            DropForeignKey("dbo.Quotes", "IdQuote", "dbo.Payments");
            DropForeignKey("dbo.Comments", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Reacts", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Reacts", "Post_IdPost", "dbo.Posts");
            DropForeignKey("dbo.Reacts", "Comments_IdComment", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Post_IdPost", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Comment_IdComment", "dbo.Comments");
            DropForeignKey("dbo.Claims", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Responses", "Claim_IdClaim", "dbo.Claims");
            DropForeignKey("dbo.Responses", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Resources", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Agents", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropForeignKey("dbo.Agents", "PointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Satisfactions", new[] { "User_IdUser" });
            DropIndex("dbo.Satisfactions", new[] { "Claim_IdClaim" });
            DropIndex("dbo.Products", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Products", new[] { "Category_IdCategory" });
            DropIndex("dbo.Quotes", new[] { "IdQuote" });
            DropIndex("dbo.Invoices", new[] { "IdInvoice" });
            DropIndex("dbo.Reacts", new[] { "User_IdUser" });
            DropIndex("dbo.Reacts", new[] { "Post_IdPost" });
            DropIndex("dbo.Reacts", new[] { "Comments_IdComment" });
            DropIndex("dbo.Posts", new[] { "User_IdUser" });
            DropIndex("dbo.Comments", new[] { "User_IdUser" });
            DropIndex("dbo.Comments", new[] { "Post_IdPost" });
            DropIndex("dbo.Comments", new[] { "Comment_IdComment" });
            DropIndex("dbo.Responses", new[] { "Claim_IdClaim" });
            DropIndex("dbo.Responses", new[] { "User_IdUser" });
            DropIndex("dbo.Claims", new[] { "User_IdUser" });
            DropIndex("dbo.Resources", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Resources", new[] { "pointOfProspection_IdPointOfProspection" });
            DropIndex("dbo.Agents", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Agents", new[] { "PointOfProspection_IdPointOfProspection" });
            DropTable("dbo.Satisfactions");
            DropTable("dbo.Products");
            DropTable("dbo.Quotes");
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.Reacts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Responses");
            DropTable("dbo.Claims");
            DropTable("dbo.Categories");
            DropTable("dbo.PointOfSales");
            DropTable("dbo.Resources");
            DropTable("dbo.PointOfProspections");
            DropTable("dbo.Agents");
        }
    }
}
