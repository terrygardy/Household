namespace Household.Data.Text.Error
{
	public static class Purchase
	{
		public static readonly string PurchaseLower = "purchase";
		public static readonly string PurchaseUpper = "Purchase";
		public static readonly string PurchasesLower = PurchaseLower + "s";
		public static readonly string PurchasesUpper = PurchaseUpper + "s";
		public static readonly string EnterDate = string.Format(TextBase.EnterValid, TextBase.DateLower + " " + TextBase.DateValidFromInBrackets);
		public static readonly string DateInFuture = string.Format(TextBase.EnterValid, TextBase.DateLower + ". " + TextBase.FutureDatesInvalid);
		public static readonly string EnterAmount = string.Format(TextBase.EnterValid, TextBase.AmountLower);
		public static readonly string EnterPayer = string.Format(TextBase.EnterValid, TextBase.PayerLower);
		public static readonly string EnterShopOrDescription = string.Format(TextBase.EnterValid, Shop.ShopLower + " " + TextBase.OrLower + " " + TextBase.DescriptionLower);
	}
}