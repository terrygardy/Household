namespace Household.Data.Text.Error
{
	public static class Person
	{
		public static readonly string PersonLower = "person";
		public static readonly string PersonUpper = "Person";
		public static readonly string EnterName = string.Format(TextBase.EnterValid, TextBase.SurnameLower);
		public static readonly string PersonExists = string.Format(TextBase.Exists, PersonLower);
	}
}