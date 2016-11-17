using Household.Localisation.Main.MasterData;

namespace Household.Data.Context
{
	using Audit;
	using Common;
	using GARTE.TypeHandling;
	using Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Text.Error;

	public partial class t_Income : DataAuditBase, IValidatableObject, IDataBase
	{
		[Key]
		public long ID { get; set; }

		[Required]
		[Column(TypeName = "date")]
		[Display(Name = "StartDate", ResourceType = typeof(IncomeText))]
		public DateTime StartDate { get; set; }

		[Column(TypeName = "date")]
		[Display(Name = "EndDate", ResourceType = typeof(IncomeText))]
		public DateTime? EndDate { get; set; }

		public long? Interval_ID { get; set; }

		[Required]
		[Display(Name = "Amount", ResourceType = typeof(IncomeText))]
		public decimal Amount { get; set; }

		public long? Payee_ID { get; set; }

		public long? Company_ID { get; set; }

		[Display(Name = "Description", ResourceType = typeof(IncomeText))]
		public string Description { get; set; }

		[Required]
		public long Day_ID { get; set; }

		[ForeignKey("Payee_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }

		[ForeignKey("Company_ID")]
		public virtual txx_Company txx_Company { get; set; }

		[ForeignKey("Interval_ID")]
		public virtual txx_Interval txx_Interval { get; set; }

		[ForeignKey("Day_ID")]
		public virtual txx_Day txx_Day { get; set; }

		public override string EntityName => "Income";
		public string EntityTitle => IncomeText.Income;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			DateTime datEnd;

			if (StartDate <= DbTools.MinDate) list.Add(new ValidationResult(Income.EnterStartDate));
			if (Interval_ID < 1) list.Add(new ValidationResult(Income.EnterInterval));
			if (Payee_ID < 1) list.Add(new ValidationResult(Income.EnterPayee));
			if ((Company_ID < 1) && (string.IsNullOrEmpty(Description))) list.Add(new ValidationResult(Income.EnterCompanyOrDescription));
			if (Amount <= 0) list.Add(new ValidationResult(Income.EnterAmount));
			if (Day_ID < 1) list.Add(new ValidationResult(Income.EnterDay));

			datEnd = Base.convertDate(EndDate);

			if ((datEnd > DbTools.MinDate) && (datEnd < StartDate)) list.Add(new ValidationResult(Income.EndDateInvalid));

			return list;
		}
	}
}
