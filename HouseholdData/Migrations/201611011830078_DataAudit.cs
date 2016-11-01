namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAudit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_Expense", "CreatedBy", c => c.String());
            AddColumn("dbo.t_Expense", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.t_Expense", "LastModifiedBy", c => c.String());
            AddColumn("dbo.t_Expense", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.txx_BankAccount", "CreatedBy", c => c.String());
            AddColumn("dbo.txx_BankAccount", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.txx_BankAccount", "LastModifiedBy", c => c.String());
            AddColumn("dbo.txx_BankAccount", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.t_Income", "CreatedBy", c => c.String());
            AddColumn("dbo.t_Income", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.t_Income", "LastModifiedBy", c => c.String());
            AddColumn("dbo.t_Income", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.txx_Company", "CreatedBy", c => c.String());
            AddColumn("dbo.txx_Company", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.txx_Company", "LastModifiedBy", c => c.String());
            AddColumn("dbo.txx_Company", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.txx_Day", "CreatedBy", c => c.String());
            AddColumn("dbo.txx_Day", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.txx_Day", "LastModifiedBy", c => c.String());
            AddColumn("dbo.txx_Day", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.txx_Interval", "CreatedBy", c => c.String());
            AddColumn("dbo.txx_Interval", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.txx_Interval", "LastModifiedBy", c => c.String());
            AddColumn("dbo.txx_Interval", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.tbr_BankAccountPerson", "CreatedBy", c => c.String());
            AddColumn("dbo.tbr_BankAccountPerson", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.tbr_BankAccountPerson", "LastModifiedBy", c => c.String());
            AddColumn("dbo.tbr_BankAccountPerson", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.t_Person", "CreatedBy", c => c.String());
            AddColumn("dbo.t_Person", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.t_Person", "LastModifiedBy", c => c.String());
            AddColumn("dbo.t_Person", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.t_Purchase", "CreatedBy", c => c.String());
            AddColumn("dbo.t_Purchase", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.t_Purchase", "LastModifiedBy", c => c.String());
            AddColumn("dbo.t_Purchase", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.txx_Shop", "CreatedBy", c => c.String());
            AddColumn("dbo.txx_Shop", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.txx_Shop", "LastModifiedBy", c => c.String());
            AddColumn("dbo.txx_Shop", "LastModifiedOn", c => c.DateTime());
            AddColumn("dbo.t_WorkDay", "CreatedBy", c => c.String());
            AddColumn("dbo.t_WorkDay", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.t_WorkDay", "LastModifiedBy", c => c.String());
            AddColumn("dbo.t_WorkDay", "LastModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_WorkDay", "LastModifiedOn");
            DropColumn("dbo.t_WorkDay", "LastModifiedBy");
            DropColumn("dbo.t_WorkDay", "CreatedOn");
            DropColumn("dbo.t_WorkDay", "CreatedBy");
            DropColumn("dbo.txx_Shop", "LastModifiedOn");
            DropColumn("dbo.txx_Shop", "LastModifiedBy");
            DropColumn("dbo.txx_Shop", "CreatedOn");
            DropColumn("dbo.txx_Shop", "CreatedBy");
            DropColumn("dbo.t_Purchase", "LastModifiedOn");
            DropColumn("dbo.t_Purchase", "LastModifiedBy");
            DropColumn("dbo.t_Purchase", "CreatedOn");
            DropColumn("dbo.t_Purchase", "CreatedBy");
            DropColumn("dbo.t_Person", "LastModifiedOn");
            DropColumn("dbo.t_Person", "LastModifiedBy");
            DropColumn("dbo.t_Person", "CreatedOn");
            DropColumn("dbo.t_Person", "CreatedBy");
            DropColumn("dbo.tbr_BankAccountPerson", "LastModifiedOn");
            DropColumn("dbo.tbr_BankAccountPerson", "LastModifiedBy");
            DropColumn("dbo.tbr_BankAccountPerson", "CreatedOn");
            DropColumn("dbo.tbr_BankAccountPerson", "CreatedBy");
            DropColumn("dbo.txx_Interval", "LastModifiedOn");
            DropColumn("dbo.txx_Interval", "LastModifiedBy");
            DropColumn("dbo.txx_Interval", "CreatedOn");
            DropColumn("dbo.txx_Interval", "CreatedBy");
            DropColumn("dbo.txx_Day", "LastModifiedOn");
            DropColumn("dbo.txx_Day", "LastModifiedBy");
            DropColumn("dbo.txx_Day", "CreatedOn");
            DropColumn("dbo.txx_Day", "CreatedBy");
            DropColumn("dbo.txx_Company", "LastModifiedOn");
            DropColumn("dbo.txx_Company", "LastModifiedBy");
            DropColumn("dbo.txx_Company", "CreatedOn");
            DropColumn("dbo.txx_Company", "CreatedBy");
            DropColumn("dbo.t_Income", "LastModifiedOn");
            DropColumn("dbo.t_Income", "LastModifiedBy");
            DropColumn("dbo.t_Income", "CreatedOn");
            DropColumn("dbo.t_Income", "CreatedBy");
            DropColumn("dbo.txx_BankAccount", "LastModifiedOn");
            DropColumn("dbo.txx_BankAccount", "LastModifiedBy");
            DropColumn("dbo.txx_BankAccount", "CreatedOn");
            DropColumn("dbo.txx_BankAccount", "CreatedBy");
            DropColumn("dbo.t_Expense", "LastModifiedOn");
            DropColumn("dbo.t_Expense", "LastModifiedBy");
            DropColumn("dbo.t_Expense", "CreatedOn");
            DropColumn("dbo.t_Expense", "CreatedBy");
        }
    }
}
