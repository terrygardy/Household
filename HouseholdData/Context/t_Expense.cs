using Household.Localisation.Main.Finance;

namespace Household.Data.Context
{
	using Audit;
	using Common;
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Text.Error;
	using System.Collections.Generic;
	using Models.Base;

	public partial class t_Expense : DataAuditBase, IValidatableObject, IDataBase
	{
		#region Properties
		[Key]
		public long ID { get; set; }

		[Required]
		[Column(TypeName = "date")]
		[Display(Name = "StartDate", ResourceType = typeof(ExpenseText))]
		public DateTime StartDate { get; set; }

		[Column(TypeName = "date")]
		[Display(Name = "EndDate", ResourceType = typeof(ExpenseText))]
		public DateTime? EndDate { get; set; }

		public long? Interval_ID { get; set; }

		public long? Company_ID { get; set; }

		[Required]
		[Display(Name = "Amount", ResourceType = typeof(ExpenseText))]
		public decimal Amount { get; set; }

		public long? BankAccount_ID { get; set; }

		public long? PaymentDay_ID { get; set; }

		[Display(Name = "Description", ResourceType = typeof(ExpenseText))]
		public string Description { get; set; }

		[ForeignKey("BankAccount_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }

		[ForeignKey("Company_ID")]
		public virtual txx_Company txx_Company { get; set; }

		[ForeignKey("PaymentDay_ID")]
		public virtual txx_Day txx_Day { get; set; }

		[ForeignKey("Interval_ID")]
		public virtual txx_Interval txx_Interval { get; set; }
		#endregion

		public override string EntityName => "Expense";
		public string EntityTitle => ExpenseText.Expense;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();
			if (StartDate <= DbTools.MinDate) list.Add(new ValidationResult(Expense.EnterStartDate));
			if ((EndDate > DbTools.MinDate) && (EndDate < StartDate)) list.Add(new ValidationResult(Expense.EnterEndDate));
			if (Interval_ID < 1) list.Add(new ValidationResult(Expense.EnterInterval));
			if (PaymentDay_ID < 1) list.Add(new ValidationResult(Expense.EnterDay));
			if (BankAccount_ID < 1) list.Add(new ValidationResult(Expense.EnterBankAccount));
			if ((Company_ID < 1) && (string.IsNullOrEmpty(Description))) list.Add(new ValidationResult(Expense.EnterCompanyOrDescription));
			if (Amount <= 0) list.Add(new ValidationResult(Expense.EnterAmount));

			return list;
		}
	}
}
