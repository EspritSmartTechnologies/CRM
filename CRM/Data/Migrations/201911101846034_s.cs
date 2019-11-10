namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reacts", name: "Comment_IdComment", newName: "IdCommentaire");
            RenameColumn(table: "dbo.Reacts", name: "Post_IdPost", newName: "IdPost");
            RenameIndex(table: "dbo.Reacts", name: "IX_Post_IdPost", newName: "IX_IdPost");
            RenameIndex(table: "dbo.Reacts", name: "IX_Comment_IdComment", newName: "IX_IdCommentaire");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reacts", name: "IX_IdCommentaire", newName: "IX_Comment_IdComment");
            RenameIndex(table: "dbo.Reacts", name: "IX_IdPost", newName: "IX_Post_IdPost");
            RenameColumn(table: "dbo.Reacts", name: "IdPost", newName: "Post_IdPost");
            RenameColumn(table: "dbo.Reacts", name: "IdCommentaire", newName: "Comment_IdComment");
        }
    }
}
