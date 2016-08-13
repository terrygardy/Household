namespace Household.Data.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddWorkDay : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.t_WorkDay",
				c => new
				{
					ID = c.Long(nullable: false, identity: true),
					WorkDay = c.DateTime(nullable: false),
					Begin = c.Time(nullable: false, precision: 7),
					End = c.Time(nullable: false, precision: 7),
					BreakDuration = c.Decimal(nullable: true, precision: 18, scale: 2),
				})
				.PrimaryKey(t => t.ID);

		}

		public override void Down()
		{
			DropTable("dbo.t_WorkDay");
		}
	}
}