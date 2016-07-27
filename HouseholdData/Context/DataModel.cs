namespace Household.Data.Context
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DataModel : DbContext
	{
		public DataModel()
			: base("name=DataModel")
		{ }

		public DataModel(string pv_strConnString)
			: base(pv_strConnString)
		{ }

		public virtual DbSet<t_Expense> t_Expense { get; set; }
		public virtual DbSet<t_Income> t_Income { get; set; }
		public virtual DbSet<t_Person> t_Person { get; set; }
		public virtual DbSet<t_Purchase> t_Purchase { get; set; }
		public virtual DbSet<tbr_BankAccountPerson> tbr_BankAccountPerson { get; set; }
		public virtual DbSet<txx_BankAccount> txx_BankAccount { get; set; }
		public virtual DbSet<txx_Company> txx_Company { get; set; }
		public virtual DbSet<txx_Day> txx_Day { get; set; }
		public virtual DbSet<txx_Interval> txx_Interval { get; set; }
		public virtual DbSet<txx_Shop> txx_Shop { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<t_Income>();

			modelBuilder.Entity<t_Person>()
				.HasMany(e => e.tbr_BankAccountPerson)
				.WithRequired(e => e.t_Person)
				.HasForeignKey(e => e.Person_ID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<txx_BankAccount>()
				.HasMany(e => e.t_Expense)
				.WithRequired(e => e.txx_BankAccount)
				.HasForeignKey(e => e.BankAccount_ID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<txx_BankAccount>()
				.HasMany(e => e.t_Income)
				.WithRequired(e => e.txx_BankAccount)
				.HasForeignKey(e => e.Payee_ID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<txx_BankAccount>()
				.HasMany(e => e.tbr_BankAccountPerson)
				.WithRequired(e => e.txx_BankAccount)
				.HasForeignKey(e => e.BankAccount_ID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<txx_Company>()
				.HasMany(e => e.t_Expense)
				.WithOptional(e => e.txx_Company)
				.HasForeignKey(e => e.Company_ID);

			modelBuilder.Entity<txx_Company>()
				.HasMany(e => e.t_Income)
				.WithOptional(e => e.txx_Company)
				.HasForeignKey(e => e.Company_ID);

			modelBuilder.Entity<txx_Day>()
				.HasMany(e => e.t_Expense)
				.WithOptional(e => e.txx_Day)
				.HasForeignKey(e => e.PaymentDay_ID);

			modelBuilder.Entity<txx_Interval>()
				.HasMany(e => e.t_Expense)
				.WithOptional(e => e.txx_Interval)
				.HasForeignKey(e => e.Interval_ID);

			modelBuilder.Entity<txx_Interval>()
				.HasMany(e => e.t_Income)
				.WithRequired(e => e.txx_Interval)
				.HasForeignKey(e => e.Interval_ID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<txx_Shop>()
				.HasMany(e => e.t_Purchase)
				.WithOptional(e => e.txx_Shop)
				.HasForeignKey(e => e.Shop_ID);
		}
	}
}
