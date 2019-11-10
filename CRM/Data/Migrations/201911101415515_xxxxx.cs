namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxxxx : DbMigration
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
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        Cat = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        IdCategory = c.Int(nullable: false),
                        Colour = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        PointOfSale_IdPointOfSale = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Categories", t => t.IdCategory)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_IdPointOfSale)
                .Index(t => t.IdCategory)
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
                "dbo.Claims",
                c => new
                    {
                        IdClaim = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdClaim)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        IdResponse = c.Int(nullable: false, identity: true),
                        ResponseDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_Id = c.String(maxLength: 128),
                        Claim_IdClaim = c.Int(),
                    })
                .PrimaryKey(t => t.IdResponse)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Claims", t => t.Claim_IdClaim)
                .Index(t => t.User_Id)
                .Index(t => t.Claim_IdClaim);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostDate = c.DateTime(nullable: false),
                        ParentId = c.Int(),
                        Content = c.String(),
                        PostId = c.Int(),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Comments", t => t.ParentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ParentId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.IdPost)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        IdReact = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Comment_IdComment = c.Int(),
                        Post_IdPost = c.Int(),
                    })
                .PrimaryKey(t => t.IdReact)
                .ForeignKey("dbo.Comments", t => t.Comment_IdComment)
                .ForeignKey("dbo.Posts", t => t.Post_IdPost)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Comment_IdComment)
                .Index(t => t.Post_IdPost);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Satisfactions",
                c => new
                    {
                        IdSatisfaction = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Claim_IdClaim = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdSatisfaction)
                .ForeignKey("dbo.Claims", t => t.Claim_IdClaim)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Claim_IdClaim)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Satisfactions", "Claim_IdClaim", "dbo.Claims");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invoices", "IdInvoice", "dbo.Payments");
            DropForeignKey("dbo.Quotes", "IdQuote", "dbo.Payments");
            DropForeignKey("dbo.Claims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Responses", "Claim_IdClaim", "dbo.Claims");
            DropForeignKey("dbo.Responses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reacts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reacts", "Post_IdPost", "dbo.Posts");
            DropForeignKey("dbo.Reacts", "Comment_IdComment", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ParentId", "dbo.Comments");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Resources", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Agents", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropForeignKey("dbo.Agents", "PointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Satisfactions", new[] { "User_Id" });
            DropIndex("dbo.Satisfactions", new[] { "Claim_IdClaim" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Quotes", new[] { "IdQuote" });
            DropIndex("dbo.Invoices", new[] { "IdInvoice" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Reacts", new[] { "Post_IdPost" });
            DropIndex("dbo.Reacts", new[] { "Comment_IdComment" });
            DropIndex("dbo.Reacts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Responses", new[] { "Claim_IdClaim" });
            DropIndex("dbo.Responses", new[] { "User_Id" });
            DropIndex("dbo.Claims", new[] { "User_Id" });
            DropIndex("dbo.Products", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropIndex("dbo.Resources", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Resources", new[] { "pointOfProspection_IdPointOfProspection" });
            DropIndex("dbo.Agents", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Agents", new[] { "PointOfProspection_IdPointOfProspection" });
            DropTable("dbo.Satisfactions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Quotes");
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Reacts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Responses");
            DropTable("dbo.Claims");
            DropTable("dbo.PointOfSales");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Resources");
            DropTable("dbo.PointOfProspections");
            DropTable("dbo.Agents");
        }
    }
}
