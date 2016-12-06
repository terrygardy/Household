using Household.BL.DATA.Base.Interfaces;
using Household.BL.DATA.t.Interfaces;
using Household.Data.Context;
using Household.Localisation.Main.Work;
using Household.BL.DATA.Attributes;

namespace Household.BL.DATA.t.Implementations
{
	[EntityName(typeof(WorkText), nameof(WorkText.WorkDay))]
	public class CWorkDayData : t_WorkDay, IWorkDay, IImportable
	{
	}
}