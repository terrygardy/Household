namespace Household.Data.Context
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Text.Error;

	public partial class txx_BankAccount : IValidatableObject
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public txx_BankAccount()
		{
			t_Expense = new HashSet<t_Expense>();
			t_Income = new HashSet<t_Income>();
			tbr_BankAccountPerson = new HashSet<tbr_BankAccountPerson>();
		}

		public long ID { get; set; }

		[Required]
		[StringLength(255)]
		public string AccountName { get; set; }

		[Required]
		[StringLength(27)]
		public string IBAN { get; set; }

		[StringLength(11)]
		public string BIC { get; set; }

		[StringLength(255)]
		public string BankName { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Expense> t_Expense { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Income> t_Income { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<tbr_BankAccountPerson> tbr_BankAccountPerson { get; set; }

		public override string ToString()
		{
			return GARTE.TypeHandling.Strings.concatStrings(AccountName, IBAN, ": ");
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (string.IsNullOrWhiteSpace(AccountName)) { list.Add(new ValidationResult(BankAccount.EnterName)); }

			if (!string.IsNullOrWhiteSpace(IBAN))
			{
				if (IBAN.Replace("-", "").Replace(" ", "").Length != 22) list.Add(new ValidationResult(BankAccount.IBANWrongLength));

				IBAN = IBAN.ToUpper();

				if (Db.CDbConnection.getInstance().txx_BankAccount.Count(x => string.Equals(x.IBAN, IBAN) && x.ID != ID) > 0) { list.Add(new ValidationResult(BankAccount.IBANExists)); }
			}

			if ((!string.IsNullOrWhiteSpace(BIC)) && (BIC.Length != 11)) { list.Add(new ValidationResult(BankAccount.BICWrongLength)); }

			return list;
		}
	}
}
