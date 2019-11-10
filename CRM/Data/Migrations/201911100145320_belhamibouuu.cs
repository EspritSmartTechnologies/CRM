namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class belhamibouuu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image");
        }
    }
}
