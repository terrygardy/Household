namespace Household.Data.Text.Error
{
	public static class Company
	{
		public static readonly string CompanyLower = "company";
		public static readonly string CompanyUpper = "Company";
		public static readonly string EnterName = string.Format(TextBase.EnterName, CompanyLower);
		public static readonly string NameExists = string.Format(TextBase.Exists, CompanyLower + " " + TextBase.NameLower);
		public static readonly string InUseIncome = string.Format(TextBase.InUse, CompanyLower, Income.IncomesLower);
		public static readonly string InUseExpense = string.Format(TextBase.InUse, CompanyLower, Expense.ExpensesLower);
	}
}