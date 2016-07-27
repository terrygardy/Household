namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Income_Clean : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_Income", "t_Income2_ID", "dbo.t_Income");
            DropIndex("dbo.t_Income", new[] { "t_Income2_ID" });
            DropColumn("dbo.t_Income", "t_Income2_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_Income", "t_Income2_ID", c => c.Long(nullable: false));
            CreateIndex("dbo.t_Income", "t_Income2_ID");
            AddForeignKey("dbo.t_Income", "t_Income2_ID", "dbo.t_Income", "ID");
        }
    }
}
