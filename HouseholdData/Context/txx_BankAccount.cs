namespace Household.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class txx_BankAccount
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
	}
}
