namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trophcccxk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Resources", new[] { "pointOfProspection_IdPointOfProspection" });
            RenameColumn(table: "dbo.Resources", name: "pointOfProspection_IdPointOfProspection", newName: "IdPointOfProspection");
            AddColumn("dbo.Agents", "IdPointOfProdpection", c => c.Int(nullable: false));
            AlterColumn("dbo.Resources", "IdPointOfProspection", c => c.Int(nullable: false));
            CreateIndex("dbo.Resources", "IdPointOfProspection");
            AddForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "IdPointOfProspection", "dbo.PointOfProspections");
            DropIndex("dbo.Resources", new[] { "IdPointOfProspection" });
            AlterColumn("dbo.Resources", "IdPointOfProspection", c => c.Int());
            DropColumn("dbo.Agents", "IdPointOfProdpection");
            RenameColumn(table: "dbo.Resources", name: "IdPointOfProspection", newName: "pointOfProspection_IdPointOfProspection");
            CreateIndex("dbo.Resources", "pointOfProspection_IdPointOfProspection");
            AddForeignKey("dbo.Resources", "pointOfProspection_IdPointOfProspection", "dbo.PointOfProspections", "IdPointOfProspection");
        }
    }
}
