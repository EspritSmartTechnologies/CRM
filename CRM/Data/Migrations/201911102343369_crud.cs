namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointOfProspections", "name", c => c.String());
            AddColumn("dbo.PointOfProspections", "lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PointOfProspections", "lon", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointOfProspections", "lon");
            DropColumn("dbo.PointOfProspections", "lat");
            DropColumn("dbo.PointOfProspections", "name");
        }
    }
}
