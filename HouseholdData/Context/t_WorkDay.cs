namespace Household.Data.Context
{
	using Common;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class t_WorkDay : IValidatableObject
	{
		#region Properties
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
				var tsDifference = End - Begin;
				var decResult = tsDifference.Hours + (tsDifference.Minutes / (decimal)60);
				return decResult - BreakDuration;
			}
		}
		#endregion

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();
			if (WorkDay <= DbTools.MinDate) list.Add(new ValidationResult("Enter work day"));
			if (Begin <= DbTools.MinTime) list.Add(new ValidationResult("Enter begin time"));
			if (End <= DbTools.MinTime) list.Add(new ValidationResult("Enter end time"));
			if (End < Begin) list.Add(new ValidationResult("The end time cannot be before the the begin time"));
			if (End <= Begin && BreakDuration > 0) list.Add(new ValidationResult("The end time cannot be before the the begin time"));
			if (BreakDuration < 0) list.Add(new ValidationResult("The break duration cannot be a minus number"));

			return list;
		}
	}
}
