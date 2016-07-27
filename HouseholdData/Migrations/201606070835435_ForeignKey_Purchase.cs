namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_Purchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Purchase", "Payer_ID", c => c.Long());
            CreateIndex("dbo.t_Purchase", "Payer_ID");
            AddForeignKey("dbo.t_Purchase", "Payer_ID", "dbo.txx_BankAccount", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Purchase", "Payer_ID", "dbo.txx_BankAccount");
            DropIndex("dbo.t_Purchase", new[] { "Payer_ID" });
            DropColumn("dbo.t_Purchase", "Payer_ID");
        }
    }
}
