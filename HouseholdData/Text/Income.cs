namespace Household.Data.Text.Error
{
	public static class Income
	{
		public static readonly string IncomeLower = "income";
		public static readonly string IncomeUpper = "Income";
		public static readonly string IncomesLower = IncomeLower + "s";
		public static readonly string IncomesUpper = IncomeUpper + "s";
		public static readonly string EnterStartDate = string.Format(TextBase.EnterValid, TextBase.StartDateLower + " " + TextBase.DateValidFromInBrackets);
		public static readonly string EnterInterval = string.Format(TextBase.EnterValid, Interval.IntervalLower);
		public static readonly string EnterCompany = string.Format(TextBase.EnterValid, Company.CompanyLower);
		public static readonly string EnterAmount = string.Format(TextBase.EnterValid, TextBase.AmountLower);
		public static readonly string EnterPayee = string.Format(TextBase.EnterValid, TextBase.PayeeLower);
		public static readonly string EnterDay = string.Format(TextBase.EnterValid, TextBase.PaymentDayLower);
		public static readonly string EnterCompanyOrDescription = string.Format(TextBase.EnterValid, Company.CompanyLower + " " + TextBase.OrLower + " " + TextBase.DescriptionLower);
		public static readonly string EndDateInvalid = string.Format(TextBase.EnterValid, TextBase.EndDateLower);
	}
}