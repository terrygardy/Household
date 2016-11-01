using System;

namespace Household.Data.Context.Audit
{
	public abstract class DataAuditBase : IDataAudit
	{
		public string CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModifiedOn { get; set; }
	}

	public interface IDataAudit
	{
		string CreatedBy { get; set; }
		DateTime? CreatedOn { get; set; }
		string LastModifiedBy { get; set; }
		DateTime? LastModifiedOn { get; set; }
	}
}