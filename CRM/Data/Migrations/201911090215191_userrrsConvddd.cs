namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrrsConvddd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "Post_IdPost" });
            RenameColumn(table: "dbo.Comments", name: "Post_IdPost", newName: "PostId");
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "PostId" });
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_IdPost");
            CreateIndex("dbo.Comments", "Post_IdPost");
        }
    }
}
