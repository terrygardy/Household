namespace Household.Data.Context
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public partial class t_WorkDay
	{
		public t_WorkDay() { }

		[Key]
		public long ID { get; set; }

		[Required]
		public DateTime WorkDay { get; set; }

		[Required]
		public TimeSpan Begin { get; set; }

		[Required]
		public TimeSpan End { get; set; }

		public decimal BreakDuration { get; set; }

		public decimal HoursWorked
		{
			get
			{
				return (Begin - End).Hours - BreakDuration;
			}
		}
	}
}
