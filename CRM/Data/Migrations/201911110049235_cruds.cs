namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cruds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PointOfProspections", "lat", c => c.Decimal(nullable: false, precision: 12, scale: 10));
            AlterColumn("dbo.PointOfProspections", "lon", c => c.Decimal(nullable: false, precision: 12, scale: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PointOfProspections", "lon", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PointOfProspections", "lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
