﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentId", c => c.Int());
            CreateIndex("dbo.Comments", "ParentId");
            AddForeignKey("dbo.Comments", "ParentId", "dbo.Comments", "IdComment");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropColumn("dbo.Comments", "ParentId");
        }
    }
}
