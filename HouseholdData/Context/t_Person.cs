namespace Household.Data.Context
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class t_Person
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public t_Person()
		{
			tbr_BankAccountPerson = new HashSet<tbr_BankAccountPerson>();
		}

		public long ID { get; set; }

		[Required]
		[StringLength(255)]
		public string Surname { get; set; }

		[StringLength(255)]
		public string Forename { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<tbr_BankAccountPerson> tbr_BankAccountPerson { get; set; }

		public override string ToString()
		{
			return GARTE.TypeHandling.Strings.concatStrings(Surname, Forename, ", ");
		}
	}
}
