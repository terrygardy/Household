using Household.BL.Functions.txx;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CBankAccountsModel
	{
		public CBankAccountsModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cBankAccount = new CBankAccount();
			var lstAccounts = cBankAccount.getBankAccounts();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "BankAccount",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Account Name";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Bank Name";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "IBAN";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var txxAccount in lstAccounts)
			{
				var strAccount = txxAccount.AccountName;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxAccount.ID.ToString()
				};

				if (!string.IsNullOrEmpty(txxAccount.BankName)) strAccount += ", " + txxAccount.BankName;
				if (!string.IsNullOrEmpty(txxAccount.IBAN)) strAccount += ", " + txxAccount.IBAN;

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxAccount.AccountName,
					CSS = "left",
					Tooltip = strAccount
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxAccount.BankName,
					CSS = "left",
					Tooltip = strAccount
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxAccount.IBAN,
					CSS = "left",
					Tooltip = strAccount
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstAccounts.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstAccounts.Count.ToString(),
				ColumnSpan = 3
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}