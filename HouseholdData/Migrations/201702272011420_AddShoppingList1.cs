namespace Household.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingList1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_ShoppingListItem",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Shop_ID = c.Long(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(),
                        LastModifiedBy = c.String(),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.txx_Shop", t => t.Shop_ID)
                .Index(t => t.Shop_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_ShoppingListItem", "Shop_ID", "dbo.txx_Shop");
            DropIndex("dbo.t_ShoppingListItem", new[] { "Shop_ID" });
            DropTable("dbo.t_ShoppingListItem");
        }
    }
}
