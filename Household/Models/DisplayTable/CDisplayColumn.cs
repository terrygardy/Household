namespace Household.Models.DisplayTable
{
    public class CDisplayColumn
    {
        public string Content { get; set; }
        public string CSS { get; set; }
        public string OnClick { get; set; }
        public int ColumnSpan { get; set; }
        public string Tooltip { get; set; }

        public CDisplayColumn()
        {
            Content = "";
            CSS = "";
            OnClick = "";
            ColumnSpan = 1;
            Tooltip = "";
        }
    }
}