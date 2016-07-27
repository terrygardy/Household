namespace Household.Data.Text
{
	public static class TextBase
	{
		public static readonly string AmountLower = "amount";
		public static readonly string AmountUpper = "Amount";
		public static readonly string BICUpper = "BIC";
		public static readonly string DateLower = "date";
		public static readonly string DateUpper = "Date";
		public static readonly string DayLower = "day";
		public static readonly string DayUpper = "Day";
		public static readonly string DescriptionLower = "description";
		public static readonly string DescriptionUpper = "Description";
		public static readonly string EndDateLower = "end date";
		public static readonly string EndDateUpper = "End Date";
		public static readonly string IBANUpper = "IBAN";
		public static readonly string NameLower = "name";
		public static readonly string NameUpper = "Name";
		public static readonly string OrLower = "or";
		public static readonly string PayeeLower = "payee";
		public static readonly string PayeeUpper = "Payee";
		public static readonly string PayerLower = "payer";
		public static readonly string PayerUpper = "Payer";
		public static readonly string PaymentLower = "payment";
		public static readonly string PaymentUpper = "Payment";
		public static readonly string PaymentDayLower = PaymentLower + " " + DayLower;
		public static readonly string PaymentDayUpper = PaymentLower + " " + DayUpper;
		public static readonly string StartDateLower = "start date";
		public static readonly string StartDateUpper = "Start Date";
		public static readonly string SurnameLower = "surname";
		public static readonly string SurnameUpper = "Surname";

		public static readonly string DateValidFrom = "dd.mm.yyyy from 01.01.1753 onwards";
		public static readonly string DateValidFromInBrackets = "(" + DateValidFrom + ")";
		public static readonly string FutureDatesInvalid = "Future dates are invalid";

		public static readonly string EnterValid = "Please enter a valid {0}";
		public static readonly string EnterName = EnterValid + " name";

		public static readonly string Exists = "The entered {0} already exists";
		public static readonly string TooLong = "The {0} is too long";
		public static readonly string InUse = "The {0} is being used by {1}";
		public static readonly string WrongLength = "The entered {0} has the wrong length. Standard length : {1}";
	}
}
