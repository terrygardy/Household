namespace Household.Data.Text.Error
{
	public static class BankAccount
	{
		public static readonly string BankAccountLower = "bank account";
		public static readonly string BankAccountUpper = "Bank Account";
		public static readonly string EnterName = string.Format(TextBase.EnterName, BankAccountLower);
		public static readonly string IBANTooLong = string.Format(TextBase.TooLong, TextBase.IBANUpper);
		public static readonly string IBANWrongLength = string.Format(TextBase.WrongLength, TextBase.IBANUpper, "22");
		public static readonly string IBANExists = string.Format(TextBase.Exists, TextBase.IBANUpper);
		public static readonly string BICTooLong = string.Format(TextBase.TooLong, TextBase.BICUpper);
		public static readonly string BICWrongLength = string.Format(TextBase.WrongLength, TextBase.BICUpper, "11");
		public static readonly string InUseIncome = string.Format(TextBase.InUse, BankAccountLower, Income.IncomesLower);
		public static readonly string InUsePurchase = string.Format(TextBase.InUse, BankAccountLower, Purchase.PurchasesLower);
		public static readonly string InUseExpense = string.Format(TextBase.InUse, BankAccountLower, Expense.ExpensesLower);
	}
}
