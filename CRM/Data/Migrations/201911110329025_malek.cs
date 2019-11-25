namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class malek : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Claims", new[] { "User_Id" });
            RenameColumn(table: "dbo.Claims", name: "User_Id", newName: "userId");
            AlterColumn("dbo.Claims", "userId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Claims", "userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Claims", new[] { "userId" });
            AlterColumn("dbo.Claims", "userId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Claims", name: "userId", newName: "User_Id");
            CreateIndex("dbo.Claims", "User_Id");
        }
    }
}
