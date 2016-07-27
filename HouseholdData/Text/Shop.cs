namespace Household.Data.Text.Error
{
	public static class Shop
	{
		public static readonly string ShopLower = "shop";
		public static readonly string ShopUpper = "Shop";
		public static readonly string EnterName = string.Format(TextBase.EnterName, ShopLower);
		public static readonly string NameExists = string.Format(TextBase.Exists, ShopLower + " " + TextBase.NameLower);
		public static readonly string InUsePurchase = string.Format(TextBase.InUse, ShopLower, Purchase.PurchasesLower);
	}
}