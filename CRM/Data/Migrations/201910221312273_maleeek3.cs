namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maleeek3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Satisfactions",
                c => new
                    {
                        IdSatisfaction = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Claim_IdClaim = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdSatisfaction)
                .ForeignKey("dbo.Claims", t => t.Claim_IdClaim)
                .ForeignKey("dbo.Users", t => t.User_IdUser)
                .Index(t => t.Claim_IdClaim)
                .Index(t => t.User_IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "User_IdUser", "dbo.Users");
            DropForeignKey("dbo.Satisfactions", "Claim_IdClaim", "dbo.Claims");
            DropIndex("dbo.Satisfactions", new[] { "User_IdUser" });
            DropIndex("dbo.Satisfactions", new[] { "Claim_IdClaim" });
            DropTable("dbo.Satisfactions");
        }
    }
}
