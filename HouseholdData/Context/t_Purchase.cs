namespace Household.Data.Context
{
	using Common;
	using Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Text.Error;

	public partial class t_Purchase : IValidatableObject, IDataBase
	{
		[Key]
		public long ID { get; set; }

		[Required]
		public DateTime Occurrence { get; set; }

		public long? Shop_ID { get; set; }

		public long? Payer_ID { get; set; }

		[Required]
		public decimal Amount { get; set; }

		public string Description { get; set; }

		[ForeignKey("Shop_ID")]
		public virtual txx_Shop txx_Shop { get; set; }

		[ForeignKey("Payer_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (Occurrence <= DbTools.MinDate) list.Add(new ValidationResult(Purchase.EnterDate));
			if (Occurrence > DateTime.Now) list.Add(new ValidationResult(Purchase.DateInFuture));

			if (Amount < 0) list.Add(new ValidationResult(Purchase.EnterAmount));
			if (Payer_ID == 0) list.Add(new ValidationResult(Purchase.EnterPayer));
			if ((Shop_ID == 0) && (string.IsNullOrEmpty(Description))) { list.Add(new ValidationResult(Purchase.EnterShopOrDescription)); }

			return list;
		}
	}
}
