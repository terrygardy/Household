using Household.BL.DATA.Base.Interfaces;
using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.Common.Reflection.Interfaces;
using Household.Localisation.Main.Import;
using System;
using System.IO;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class ImportController : Controller
	{
		#region ctor

		private readonly IImportManagement _importManagement;
		private readonly IReflectionManager _reflectionManager;

		public ImportController(IImportManagement importManagement,
			IReflectionManager reflectionManager)
		{
			_importManagement = importManagement;
			_reflectionManager = reflectionManager;
		}
		#endregion

		public ActionResult Index()
		{
			return View(new CImportViewModel(_importManagement.GetImportableTypes()));
		}

		public ActionResult Import()
		{
			var file = Request.Files.Count > 0 ? Request.Files[0] : null;

			if (file != null)
			{
				var fileName = Path.GetTempFileName();

				file.SaveAs(fileName);

				try
				{
					var type = Request.Form.GetValues(nameof(CImportViewModel.ImportableTypes))[0];

					if (typeof(CWorkDayData).AssemblyQualifiedName.Equals(type, StringComparison.OrdinalIgnoreCase))
					{
						_importManagement.SimpleImportExcelFile<CWorkDayData>(fileName);
					}
					else {
						return View("ImportError", (object)string.Format(ImportText.NotSupported));
					}
				}
				catch (Exception ex)
				{
					return View("ImportError", (object)ex.Message);
				}
				finally
				{
					System.IO.File.Delete(fileName);
				}

				return View("ImportSuccessful");
			}

			return View("ImportError", (object)"No file found!");
		}

		/*
		 Test

		public ActionResult Index()
		{
			var filePath = @"C:\DATA\Projects\Household\TestFiles\PurchaseImport.xml";
			var purchase = new t_Purchase { ID = 2, Amount = 20, Description = "Test", Payer_ID = 1, Shop_ID = 1, Occurrence = DateTime.Today };

			SerializeObject(purchase, filePath);

			var result = DeserializeObject<t_Purchase>(filePath);

			return View();
		}

		private T DeserializeObject<T>(string filename)
		{
			// Create an instance of the XmlSerializer specifying type and namespace.
			var serializer = new XmlSerializer(typeof(T));

			// A FileStream is needed to read the XML document.
			var fs = new FileStream(filename, FileMode.Open);
			var reader = XmlReader.Create(fs);

			// Declare an object variable of the type to be deserialized.
			T i;

			// Use the Deserialize method to restore the object's state.
			i = (T)serializer.Deserialize(reader);
			fs.Close();

			return i;
		}

		private void SerializeObject<T>(T source, string filename)
		{
			// Create an instance of the XmlSerializer specifying type and namespace.
			var serializer = new XmlSerializer(typeof(T));

			// A FileStream is needed to read the XML document.
			if (System.IO.File.Exists(filename)) { System.IO.File.Delete(filename); }

			var fs = new FileStream(filename, FileMode.CreateNew);
			var writer = XmlWriter.Create(fs);

			// Use the Deserialize method to restore the object's state.
			serializer.Serialize(writer, source);
			fs.Close();
		}
		 */
	}

	public class CImportViewModel
	{
		public System.Collections.Generic.List<SelectListItem> ImportableTypes { get; private set; }

		public CImportViewModel(System.Collections.Generic.List<IImportType> importableTypes)
		{
			LoadTypes(importableTypes);
		}

		public void LoadTypes(System.Collections.Generic.List<IImportType> importableTypes)
		{
			if (importableTypes != null)
			{
				ImportableTypes = new System.Collections.Generic.List<SelectListItem>();
				importableTypes.ForEach(it => ImportableTypes.Add(new SelectListItem() { Value = it.AssemblyQualifiedName, Text = it.EntityTitle, Group = new SelectListGroup(), Disabled = false, Selected = false }));
			}
		}
	}
}