using System.IO;

namespace GARTE.Log
{
	public static class Logger
	{
		public static string ApplicationLogFileName = "GARTE_application_log.log";
		private const string LogEntry = "Logged on {0}: {1}";

		public static void WriteToLog(string message)
		{
			var fileName = Path.Combine(Path.GetTempPath(), ApplicationLogFileName);

			using (var writer = new StreamWriter(fileName, true, System.Text.Encoding.UTF8)) {
				writer.WriteLine(string.Format(LogEntry, System.DateTime.Now.ToString("dd.MM.yyyy 'at' HH:mm"), message));
			}
		}
	}
}