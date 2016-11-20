using Household.Data.Context.Audit;
using Household.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Household.Localisation.Main.Banking;
using Household.Data.Text;

namespace Household.Data.Context
{
	public partial class t_BankBalance : DataAuditBase, IValidatableObject, IDataBase
	{
		private DateTime m_datNULL => new DateTime(1753, 1, 1);
		public override string EntityName => "BankBalance";
		public string EntityTitle => BankingText.BankBalance;

		[Key]
		public long ID { get; set; }

		[Required]
		public DateTime ReferenceDate { get; set; }

		[Required]
		public decimal Balance { get; set; }

		[Required]
		public long BankAccount_ID { get; set; }

		[ForeignKey("BankAccount_ID")]
		public virtual txx_BankAccount BankAccount { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (ReferenceDate <= m_datNULL) yield return new ValidationResult(Banking.InValidReferenceDate);
		}
	}
}