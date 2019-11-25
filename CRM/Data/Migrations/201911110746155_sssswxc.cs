namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssswxc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "idClaim", "dbo.Claims");
            DropForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims");
            DropIndex("dbo.Responses", new[] { "User_Id" });
            DropIndex("dbo.Satisfactions", new[] { "User_Id" });
            DropColumn("dbo.Responses", "IdUser");
            DropColumn("dbo.Satisfactions", "idUser");
            RenameColumn(table: "dbo.Responses", name: "User_Id", newName: "IdUser");
            RenameColumn(table: "dbo.Satisfactions", name: "User_Id", newName: "idUser");
            AlterColumn("dbo.Responses", "IdUser", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Responses", "IdUser", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Satisfactions", "idUser", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Satisfactions", "idUser", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Responses", "IdUser");
            CreateIndex("dbo.Satisfactions", "idUser");
            AddForeignKey("dbo.Responses", "idClaim", "dbo.Claims", "IdClaim");
            AddForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims", "IdClaim");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims");
            DropForeignKey("dbo.Responses", "idClaim", "dbo.Claims");
            DropIndex("dbo.Satisfactions", new[] { "idUser" });
            DropIndex("dbo.Responses", new[] { "IdUser" });
            AlterColumn("dbo.Satisfactions", "idUser", c => c.String(maxLength: 128));
            AlterColumn("dbo.Satisfactions", "idUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Responses", "IdUser", c => c.String(maxLength: 128));
            AlterColumn("dbo.Responses", "IdUser", c => c.String());
            RenameColumn(table: "dbo.Satisfactions", name: "idUser", newName: "User_Id");
            RenameColumn(table: "dbo.Responses", name: "IdUser", newName: "User_Id");
            AddColumn("dbo.Satisfactions", "idUser", c => c.Int(nullable: false));
            AddColumn("dbo.Responses", "IdUser", c => c.String());
            CreateIndex("dbo.Satisfactions", "User_Id");
            CreateIndex("dbo.Responses", "User_Id");
            AddForeignKey("dbo.Satisfactions", "IdClaim", "dbo.Claims", "IdClaim", cascadeDelete: true);
            AddForeignKey("dbo.Responses", "idClaim", "dbo.Claims", "IdClaim", cascadeDelete: true);
        }
    }
}
