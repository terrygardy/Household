namespace Household.Data.Text.Error
{
	public static class Expense
	{
		public static readonly string ExpenseLower = "expense";
		public static readonly string ExpenseUpper = "Expense";
		public static readonly string ExpensesLower = ExpenseLower + "s";
		public static readonly string ExpensesUpper = ExpenseUpper + "s";
		public static readonly string EnterStartDate = string.Format(TextBase.EnterValid, TextBase.StartDateLower + " " + TextBase.DateValidFromInBrackets);
		public static readonly string EnterEndDate = string.Format(TextBase.EnterValid, TextBase.EndDateLower);
		public static readonly string EnterInterval = string.Format(TextBase.EnterValid, Interval.IntervalLower);
		public static readonly string EnterCompany = string.Format(TextBase.EnterValid, Company.CompanyLower);
		public static readonly string EnterAmount = string.Format(TextBase.EnterValid, TextBase.AmountLower);
		public static readonly string EnterBankAccount = string.Format(TextBase.EnterValid, BankAccount.BankAccountLower);
		public static readonly string EnterDay = string.Format(TextBase.EnterValid, TextBase.PaymentDayLower);
		public static readonly string EnterCompanyOrDescription = string.Format(TextBase.EnterValid, Company.CompanyLower + " " + TextBase.OrLower + " " + TextBase.DescriptionLower);
	}
}