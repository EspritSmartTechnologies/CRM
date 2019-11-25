namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "Claim_IdClaim", "dbo.Claims");
            DropIndex("dbo.Responses", new[] { "Claim_IdClaim" });
            RenameColumn(table: "dbo.Responses", name: "Claim_IdClaim", newName: "idClaim");
            AlterColumn("dbo.Responses", "idClaim", c => c.Int(nullable: false));
            CreateIndex("dbo.Responses", "idClaim");
            AddForeignKey("dbo.Responses", "idClaim", "dbo.Claims", "IdClaim", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "idClaim", "dbo.Claims");
            DropIndex("dbo.Responses", new[] { "idClaim" });
            AlterColumn("dbo.Responses", "idClaim", c => c.Int());
            RenameColumn(table: "dbo.Responses", name: "idClaim", newName: "Claim_IdClaim");
            CreateIndex("dbo.Responses", "Claim_IdClaim");
            AddForeignKey("dbo.Responses", "Claim_IdClaim", "dbo.Claims", "IdClaim");
        }
    }
}
