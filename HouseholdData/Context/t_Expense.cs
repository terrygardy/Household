namespace Household.Data.Context
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class t_Expense
	{
		public long ID { get; set; }

		[Column(TypeName = "date")]
		public DateTime StartDate { get; set; }

		[Column(TypeName = "date")]
		public DateTime? EndDate { get; set; }

		public long? Interval_ID { get; set; }

		public long? Company_ID { get; set; }

		public decimal Amount { get; set; }

		public long BankAccount_ID { get; set; }

		public long? PaymentDay_ID { get; set; }

		public string Description { get; set; }

		[ForeignKey("BankAccount_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }

		[ForeignKey("Company_ID")]
		public virtual txx_Company txx_Company { get; set; }

		[ForeignKey("PaymentDay_ID")]
		public virtual txx_Day txx_Day { get; set; }

		[ForeignKey("Interval_ID")]
		public virtual txx_Interval txx_Interval { get; set; }
	}
}