using System;
using System.Collections.Generic;

namespace Household.BL.Management.t.Interfaces
{
	public interface IImportManagement
	{
		List<Type> GetImportableTypes();

		void ImportExcelFile(string fileName);
	}
}