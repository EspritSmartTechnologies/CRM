namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belhamibouu : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Category_IdCategory" });
            RenameColumn(table: "dbo.Products", name: "Category_IdCategory", newName: "IdCategory");
            AlterColumn("dbo.Products", "IdCategory", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "IdCategory");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "IdCategory" });
            AlterColumn("dbo.Products", "IdCategory", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "IdCategory", newName: "Category_IdCategory");
            CreateIndex("dbo.Products", "Category_IdCategory");
        }
    }
}
