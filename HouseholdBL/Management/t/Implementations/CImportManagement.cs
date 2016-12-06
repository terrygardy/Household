using Household.BL.DATA.Attributes;
using Household.BL.DATA.Base.Implementations;
using Household.BL.DATA.Base.Interfaces;
using Household.BL.DATA.t.Implementations;
using Household.BL.ExcelHelpers.Exceptions;
using Household.BL.Management.t.Interfaces;
using Household.Common.Reflection.Interfaces;
using Household.Localisation.Main.Import;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Household.BL.Management.t.Implementations
{
	public class CImportManagement : IImportManagement
	{
		private readonly IReflectionManager _reflectionManager;
		private readonly IWorkDayManagement _workManagement;

		public CImportManagement(IReflectionManager reflectionManager,
			IWorkDayManagement workManagement)
		{
			_reflectionManager = reflectionManager;
			_workManagement = workManagement;
		}

		public List<IImportType> GetImportableTypes()
		{
			var importables = new List<IImportType>();

			foreach (var type in _reflectionManager.GetTypesByInterface<IImportable>())
			{
				var entityAttribute = _reflectionManager.GetCustomAttribute<EntityNameAttribute>(type, false);

				if (entityAttribute == null) throw new ArgumentNullException("EntityName must be added to every importable type, see CWorkDayData");

				importables.Add(new CImportType
				{
					AssemblyQualifiedName = type.AssemblyQualifiedName,
					EntityTitle = entityAttribute.EntityName
				});
			}

			return importables;
		}

		public void SimpleImportExcelFile<T>(string fileName)
			where T : class, IImportable, new()
		{
			var worksheet = ExcelHelpers.Factory.GetFirstWorksheet(fileName);

			if (worksheet.LastRowNum > 0)
			{
				var targets = new List<T>();
				var cellTitles = ExcelHelpers.Factory.GetTitleRow(worksheet).ToDictionary(tr => tr.Key, tr => tr.Value);

				for (int rowIndex = 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
				{
					try
					{
						targets.Add(ImportRow<T>(worksheet.GetRow(rowIndex), cellTitles));
					}
					catch (NoDataToImportException) { break; }
				}

				if (targets.Count > 0)
				{
					if (targets[0] is CWorkDayData)
					{
						_workManagement.save(targets as List<CWorkDayData>);
					}
					else
					{
						throw new NotImplementedException($"{ImportText.NotSupported} : {typeof(T).Name}");
					}
				}
			}
		}

		private T ImportRow<T>(IRow currentRow, IDictionary<int, string> cellTitles)
			where T : class, IImportable, new()
		{
			if (currentRow != null) //null is when the row only contains empty cells
			{
				var targetProperties = _reflectionManager.GetProperties<T>();
				var target = _reflectionManager.CreateInstance<T>();
				var amountNullCells = 0;

				for (var cellIndex = 0; cellIndex < currentRow.Cells.Count; cellIndex++)
				{
					try
					{
						var targetProp = targetProperties.FirstOrDefault(p => p.Name.Equals(cellTitles[cellIndex], StringComparison.OrdinalIgnoreCase));

						targetProp.SetValue(target,
							ExcelHelpers.Factory.GetTypedCellContent(currentRow.GetCell(cellIndex), targetProp.PropertyType));
					}
					catch (InvalidCastException)
					{
						amountNullCells += 1;
					}
					catch (FormatException)
					{
						amountNullCells += 1;
					}
					catch (ArgumentNullException)
					{
						amountNullCells += 1;
					}
					catch (NullReferenceException)
					{
						amountNullCells += 1;
					}
				}

				if (amountNullCells == currentRow.Cells.Count) throw new NoDataToImportException();

				return target;
			}

			throw new NoDataToImportException();
		}
	}
}