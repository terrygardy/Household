using Household.BL.DATA.Base.Interfaces;

namespace Household.BL.DATA.Base.Implementations
{
	public class CImportType : IImportType
	{
		public string EntityTitle { get; set; }
		public string AssemblyQualifiedName { get; set; }
	}
}