namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxxxxx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
