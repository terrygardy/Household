using Household.Localisation.Main.Work;

namespace Household.Data.Context
{
	using Common;
	using Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;

	public partial class t_WorkDay : IValidatableObject, IDataBase
	{
		#region Properties
		public t_WorkDay() { }

		[Key]
		public long ID { get; set; }

		[Required]
		[Display(Name = "WorkDay", ResourceType = typeof(WorkText))]
		public DateTime WorkDay { get; set; }

		[Required]
		[Display(Name = "Begin", ResourceType = typeof(WorkText))]
		public TimeSpan Begin { get; set; }

		[Required]
		[Display(Name = "End", ResourceType = typeof(WorkText))]
		public TimeSpan End { get; set; }

		[Display(Name = "BreakDuration", ResourceType = typeof(WorkText))]
		public decimal BreakDuration { get; set; }

		[Display(Name = "HoursWorked", ResourceType = typeof(WorkText))]
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

			if (Db.CDbConnection.getInstance().t_WorkDay.Count(x => x.WorkDay == WorkDay
																&& x.Begin <= Begin
																&& x.End >= Begin
																&& x.ID != ID) > 0) list.Add(new ValidationResult("This time frame has already been entered"));

			return list;
		}
	}
}
