using Household.Localisation.Main.Finance;

namespace Household.Data.Context
{
	using Audit;
	using Common;
	using Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;
	using Text.Error;

	[Serializable]
	public partial class t_Purchase : DataAuditBase, IValidatableObject, IDataBase
	{
		[Key]
		public long ID { get; set; }

		[Required]
		[Display(Name = "Occurrence", ResourceType = typeof(PurchaseText))]
		public DateTime Occurrence { get; set; }

		public long? Shop_ID { get; set; }

		public long? Payer_ID { get; set; }

		[Required]
		[Display(Name = "Amount", ResourceType = typeof(PurchaseText))]
		public decimal Amount { get; set; }

		[Display(Name = "Description", ResourceType = typeof(PurchaseText))]
		public string Description { get; set; }

		[IgnoreDataMember]
		[XmlIgnore]
		[ForeignKey("Shop_ID")]
		public virtual txx_Shop txx_Shop { get; set; }

		[IgnoreDataMember]
		[XmlIgnore]
		[ForeignKey("Payer_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }

		public override string EntityName => "Purchase";
		public string EntityTitle => PurchaseText.Purchase;

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
