namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maleeek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointOfProspections",
                c => new
                    {
                        IdPointOfProspection = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPointOfProspection);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.IdProduct);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Colour = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_IdProduct = c.Int(),
                        PointOfSale_IdPointOfSale = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Categories", t => t.Category_IdProduct)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_IdPointOfSale)
                .Index(t => t.Category_IdProduct)
                .Index(t => t.PointOfSale_IdPointOfSale);
            
            AddColumn("dbo.Agents", "PointOfProspection_IdPointOfProspection", c => c.Int());
            AddColumn("dbo.PointOfSales", "Adress", c => c.String());
            AddColumn("dbo.PointOfSales", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "pointOfProspection_IdPointOfProspection", c => c.Int());
            CreateIndex("dbo.Agents", "PointOfProspection_IdPointOfProspection");
            CreateIndex("dbo.Resources", "pointOfProspection_IdPointOfProspection");
            AddForeignKey("dbo.Agents", "PointOfProspection_IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection");
            AddForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PointOfSale_IdPointOfSale", "dbo.PointOfSales");
            DropForeignKey("dbo.Products", "Category_IdProduct", "dbo.Categories");
            DropForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropForeignKey("dbo.Agents", "PointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Products", new[] { "PointOfSale_IdPointOfSale" });
            DropIndex("dbo.Products", new[] { "Category_IdProduct" });
            DropIndex("dbo.Resources", new[] { "pointOfProspection_IdPointOfProspection" });
            DropIndex("dbo.Agents", new[] { "PointOfProspection_IdPointOfProspection" });
            DropColumn("dbo.Resources", "pointOfProspection_IdPointOfProspection");
            DropColumn("dbo.PointOfSales", "Phone");
            DropColumn("dbo.PointOfSales", "Adress");
            DropColumn("dbo.Agents", "PointOfProspection_IdPointOfProspection");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.PointOfProspections");
        }
    }
}
