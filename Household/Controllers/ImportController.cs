using System.Web.Mvc;

namespace Household.Controllers
{
	public class ImportController : Controller
	{
		// GET: Import
		public ActionResult Index() { return View(); }
		
		public ActionResult Import()
		{
			var file = Request.Files[0];

			if (file != null) {
				return View("ImportSuccessful");
			}

			return View("ImportError", (object)"This is an error!!!!");
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
}