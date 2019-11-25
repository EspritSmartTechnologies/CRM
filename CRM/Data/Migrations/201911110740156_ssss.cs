namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Satisfactions", "Claim_IdClaim", "dbo.Claims");
            DropIndex("dbo.Satisfactions", new[] { "Claim_IdClaim" });
            RenameColumn(table: "dbo.Satisfactions", name: "Claim_IdClaim", newName: "IdClaim");
            AddColumn("dbo.Satisfactions", "idUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Satisfactions", "IdClaim", c => c.Int(nullable: false));
            CreateIndex("dbo.Satisfactions", "IdClaim");
            AddForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims", "IdClaim", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims");
            DropIndex("dbo.Satisfactions", new[] { "IdClaim" });
            AlterColumn("dbo.Satisfactions", "IdClaim", c => c.Int());
            DropColumn("dbo.Satisfactions", "idUser");
            RenameColumn(table: "dbo.Satisfactions", name: "IdClaim", newName: "Claim_IdClaim");
            CreateIndex("dbo.Satisfactions", "Claim_IdClaim");
            AddForeignKey("dbo.Satisfactions", "Claim_IdClaim", "dbo.Claims", "IdClaim");
        }
    }
}
