namespace Household.Data.Text.Error
{
	public static class Day
	{
		public static readonly string Invalid = string.Format(TextBase.EnterValid, " " + TextBase.DayLower + " (1 - 31)");
		public static readonly string DayExists = string.Format(TextBase.Exists, " " + TextBase.DayLower);
		public static readonly string InUseIncome = string.Format(TextBase.InUse, TextBase.DayLower, Income.IncomesLower);
		public static readonly string InUseExpense = string.Format(TextBase.InUse, TextBase.DayLower, Expense.ExpensesLower);
	}
}