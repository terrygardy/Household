namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IBAN : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_Expense", "PaymentDay_ID", "dbo.txx_Day");
            DropForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day");
            DropPrimaryKey("dbo.txx_Day");
            AlterColumn("dbo.txx_BankAccount", "IBAN", c => c.String(maxLength: 27));
            AlterColumn("dbo.txx_Day", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.txx_Day", "ID");
            AddForeignKey("dbo.t_Expense", "PaymentDay_ID", "dbo.txx_Day", "ID");
            AddForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day");
            DropForeignKey("dbo.t_Expense", "PaymentDay_ID", "dbo.txx_Day");
            DropPrimaryKey("dbo.txx_Day");
            AlterColumn("dbo.txx_Day", "ID", c => c.Long(nullable: false));
            AlterColumn("dbo.txx_BankAccount", "IBAN", c => c.String(maxLength: 22));
            AddPrimaryKey("dbo.txx_Day", "ID");
            AddForeignKey("dbo.t_Income", "txx_Day_ID", "dbo.txx_Day", "ID");
            AddForeignKey("dbo.t_Expense", "PaymentDay_ID", "dbo.txx_Day", "ID");
        }
    }
}
