using Household.Localisation.Main.MasterData;

namespace Household.Data.Context
{
	using Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Text.Error;

	public partial class t_Person : IValidatableObject, IDataBase
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public t_Person()
		{
			tbr_BankAccountPerson = new HashSet<tbr_BankAccountPerson>();
		}

		[Key]
		public long ID { get; set; }

		[Required]
		[StringLength(255)]
		[Display(Name = "Surname", ResourceType = typeof(PersonText))]
		public string Surname { get; set; }

		[StringLength(255)]
		[Display(Name = "Forename", ResourceType = typeof(PersonText))]
		public string Forename { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<tbr_BankAccountPerson> tbr_BankAccountPerson { get; set; }

		public override string ToString()
		{
			return GARTE.TypeHandling.Strings.concatStrings(Surname, Forename, ", ");
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (string.IsNullOrWhiteSpace(Surname)) { list.Add(new ValidationResult(Person.EnterName)); }

			if (string.IsNullOrWhiteSpace(Forename)) Forename = "";

			Surname = Surname.Trim();
			Forename = Forename.Trim();

			if (Db.CDbConnection.getInstance().t_Person.Count(x => x.ID != ID &&
						 string.Compare(x.Surname, Surname, true) == 0 &&
						 string.Compare(x.Forename, Forename, true) == 0) > 0) list.Add(new ValidationResult(Person.PersonExists));

			return list;
		}
	}
}
