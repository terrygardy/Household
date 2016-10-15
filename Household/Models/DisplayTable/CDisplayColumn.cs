namespace Household.Models.DisplayTable
{
	public class CDisplayColumn
	{
		private object _tooltip;

		public object Content { get; set; }
		public string CSS { get; set; }
		public string OnClick { get; set; }
		public int ColumnSpan { get; set; }
		public object Tooltip
		{
			get { return _tooltip ?? Content; }
			set { _tooltip = value; }
		}

		public CDisplayColumn()
		{
			CSS = "";
			OnClick = "";
			ColumnSpan = 1;
		}
	}
}