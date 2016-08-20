namespace Household.Data.Context
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Text.Error;

	public partial class txx_Interval : IValidatableObject
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public txx_Interval()
		{
			t_Expense = new HashSet<t_Expense>();
			t_Income = new HashSet<t_Income>();
		}

		[Key]
		public long ID { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Expense> t_Expense { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Income> t_Income { get; set; }

		public override string ToString()
		{
			return GARTE.TypeHandling.Base.convertString(Name);
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (string.IsNullOrEmpty(Name)) { list.Add(new ValidationResult(Interval.EnterName)); }

			if (Db.CDbConnection.getInstance().txx_Interval.Count(x => string.Equals(x.Name, Name) && x.ID != ID) > 0) { list.Add(new ValidationResult(Interval.NameExists)); }

			return list;
		}
	}
}
