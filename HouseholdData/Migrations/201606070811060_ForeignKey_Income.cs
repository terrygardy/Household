namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_Income : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day");
            DropIndex("dbo.t_Income", new[] { "txx_Day_ID" });
            DropColumn("dbo.t_Income", "Day_ID");
            RenameColumn(table: "dbo.t_Income", name: "txx_Day_ID", newName: "Day_ID");
            AlterColumn("dbo.t_Income", "Day_ID", c => c.Long(nullable: false));
            CreateIndex("dbo.t_Income", "Day_ID");
            AddForeignKey("dbo.t_Income", "Day_ID", "dbo.txx_Day", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Income", "Day_ID", "dbo.txx_Day");
            DropIndex("dbo.t_Income", new[] { "Day_ID" });
            AlterColumn("dbo.t_Income", "Day_ID", c => c.Long());
            RenameColumn(table: "dbo.t_Income", name: "Day_ID", newName: "txx_Day_ID");
            AddColumn("dbo.t_Income", "Day_ID", c => c.Long(nullable: false));
            CreateIndex("dbo.t_Income", "txx_Day_ID");
            AddForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day", "ID");
        }
    }
}
