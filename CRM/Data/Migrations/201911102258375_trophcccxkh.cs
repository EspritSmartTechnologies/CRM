namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trophcccxkh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Agents", new[] { "PointOfProspection_IdPointOfProspection" });
            DropColumn("dbo.Agents", "IdPointOfProdpection");
            RenameColumn(table: "dbo.Agents", name: "PointOfProspection_IdPointOfProspection", newName: "IdPointOfProdpection");
            AlterColumn("dbo.Agents", "IdPointOfProdpection", c => c.Int(nullable: false));
            CreateIndex("dbo.Agents", "IdPointOfProdpection");
            AddForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Agents", new[] { "IdPointOfProdpection" });
            AlterColumn("dbo.Agents", "IdPointOfProdpection", c => c.Int());
            RenameColumn(table: "dbo.Agents", name: "IdPointOfProdpection", newName: "PointOfProspection_IdPointOfProspection");
            AddColumn("dbo.Agents", "IdPointOfProdpection", c => c.Int(nullable: false));
            CreateIndex("dbo.Agents", "PointOfProspection_IdPointOfProspection");
            AddForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection", cascadeDelete: true);
        }
    }
}
