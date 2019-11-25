namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trophcccx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Trophies", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Trophies");
        }
    }
}
