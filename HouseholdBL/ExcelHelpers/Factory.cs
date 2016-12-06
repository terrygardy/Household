using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Household.BL.ExcelHelpers
{
	public static class Factory
	{
		public static IWorkbook GetWorkbook(string fileName)
		{
			using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				return new XSSFWorkbook(file);
			}
		}

		public static ISheet GetFirstWorksheet(string fileName)
		{
			return GetFirstWorksheet(GetWorkbook(fileName));
		}

		public static ISheet GetFirstWorksheet(IWorkbook workbook)
		{
			return GetWorksheet(workbook, 0);
		}

		public static ISheet GetWorksheet(IWorkbook workbook, int worksheetIndex)
		{
			return workbook.GetSheetAt(worksheetIndex);
		}

		public static IEnumerable<KeyValuePair<int, string>> GetTitleRow(ISheet worksheet)
		{
			var titleRow = worksheet.GetRow(0);

			for (var i = 0; i < titleRow.Cells.Count; i++)
			{
				var cellTitle = titleRow.GetCell(i)?.ToString();

				if (string.IsNullOrEmpty(cellTitle)) break;

				yield return new KeyValuePair<int, string>(i, cellTitle);
			}
		}

		public static object GetTypedCellContent<T>(ICell currentCell)
		{
			return GetTypedCellContent(currentCell, typeof(T));
		}

		public static object GetTypedCellContent(ICell currentCell, Type targetType)
		{
			object cellContent;

			switch (currentCell.CellType)
			{
				case CellType.Boolean:
					cellContent = currentCell.BooleanCellValue;
					break;

				case CellType.Numeric:

					if (DateUtil.IsCellDateFormatted(currentCell))
					{
						var tempValue = currentCell.DateCellValue;

						if (tempValue.Hour > 0 || tempValue.Minute > 0 || tempValue.Second > 0)
						{
							cellContent = new TimeSpan(tempValue.Hour, tempValue.Minute, tempValue.Second);
						}
						else
						{
							cellContent = tempValue;
						}
					}
					else
					{
						cellContent = currentCell.NumericCellValue;

						if (targetType == typeof(decimal))
						{
							cellContent = decimal.Parse(cellContent.ToString());
						}
					}

					break;

				case CellType.String:
					cellContent = currentCell.StringCellValue;
					break;

				default:
					cellContent = currentCell.ToString();
					break;
			}

			return Convert.ChangeType(cellContent, targetType);
		}
	}
}