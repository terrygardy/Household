namespace Household.Data.Text.Error
{
	public static class Interval
	{
		public static readonly string IntervalLower = "interval";
		public static readonly string IntervalUpper = "Interval";
		public static readonly string EnterName = string.Format(TextBase.EnterName, IntervalLower);
		public static readonly string NameExists = string.Format(TextBase.Exists, IntervalLower + " " + TextBase.NameLower);
		public static readonly string InUseIncome = string.Format(TextBase.InUse, IntervalLower, Income.IncomesLower);
		public static readonly string InUseExpense = string.Format(TextBase.InUse, IntervalLower, Expense.ExpensesLower);
	}
}
