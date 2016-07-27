namespace Household.Data.Context
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class txx_Day
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
	}
}
