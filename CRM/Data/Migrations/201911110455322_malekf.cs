namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class malekf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Responses", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Responses", "IdUser");
        }
    }
}
