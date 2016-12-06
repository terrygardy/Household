using Household.BL.DATA.Base.Interfaces;
using System.Collections.Generic;

namespace Household.BL.Management.t.Interfaces
{
	public interface IImportManagement
	{
		List<IImportType> GetImportableTypes();

		void SimpleImportExcelFile<T>(string fileName)
			where T : class, IImportable, new();
	}
}