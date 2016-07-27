namespace Household.Test.Text
{
	public static class TextBase
	{
		public static readonly string ErrorUnknown = "Unknown error";
		public static readonly string ErrorOnTestObject = "Error while creating instance of test object";
		public static readonly string TestDescription = "This is a test description";
		private static readonly string ErrorEdit = "{0} not edited: {1}";
		private static readonly string ErrorSave = "{0} not saved: {1}";
		private static readonly string ErrorDelete = "{0} not deleted: {1}";
		private static readonly string ErrorNotFound = "{0} not found: {1}";

		public static string getErrorEdit(string pv_strObjectName, string pv_strErrorMessage)
		{
			return string.Format(ErrorEdit, pv_strObjectName, pv_strErrorMessage);
		}

		public static string getErrorSave(string pv_strObjectName, string pv_strErrorMessage)
		{
			return string.Format(ErrorSave, pv_strObjectName, pv_strErrorMessage);
		}

		public static string getErrorDelete(string pv_strObjectName, string pv_strErrorMessage)
		{
			return string.Format(ErrorDelete, pv_strObjectName, pv_strErrorMessage);
		}

		public static string getErrorNotFound(string pv_strObjectName, string pv_strErrorMessage)
		{
			return string.Format(ErrorNotFound, pv_strObjectName, pv_strErrorMessage);
		}
	}
}
