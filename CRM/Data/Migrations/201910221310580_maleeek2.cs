namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maleeek2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "Content", c => c.String());
            AddColumn("dbo.Responses", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Responses", "Content");
            DropColumn("dbo.Claims", "Content");
        }
    }
}
