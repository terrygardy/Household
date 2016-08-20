namespace Household.Data.Context
{
	using Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;

	public partial class txx_Day : IValidatableObject, IDataBase
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public txx_Day()
		{
			t_Expense = new HashSet<t_Expense>();
		}

		public long ID { get; set; }

		[Required]
		public int Day { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Expense> t_Expense { get; set; }

		public override string ToString()
		{
			string strDay = Day.ToString();
			char cLast = strDay.Substring(strDay.Length - 1)[0];

			switch (cLast)
			{
				case '1':
					strDay += "st";
					break;
				case '2':
					strDay += "nd";
					break;
				case '3':
					strDay += "rd";
					break;
				default:
					strDay += "th";
					break;
			}

			return strDay;
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if ((Day < 1) || (Day > 31)) { list.Add(new ValidationResult(Text.Error.Day.Invalid)); }

			if (Db.CDbConnection.getInstance().txx_Day.Count(x => x.Day == Day && x.ID != ID) > 0) { list.Add(new ValidationResult(Text.Error.Day.DayExists)); }

			return list;
		}
	}
}
