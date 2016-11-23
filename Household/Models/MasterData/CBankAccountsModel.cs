using Household.Localisation.Common;
using Household.Localisation.Main.MasterData;
using Household.Models.DisplayTable;
using System.Linq;
using Household.BL.Management.txx.Interfaces;

namespace Household.Models.MasterData
{
	public class CBankAccountsModel
	{
		private readonly IBankAccountManagement _bankAccountManagement;

		public CBankAccountsModel(IBankAccountManagement bankAccountManagement)
		{
			_bankAccountManagement = bankAccountManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstAccounts = _bankAccountManagement.getBankAccounts();
			var action = "BankAccount";
			var controller = "MasterData";
			var dtTable = new CDisplayTable()
			{
				AddAction = action,
				AddController = controller
			};
			var drHead = new CDisplayRow()
			{
				OnClickAction = action,
				OnClickController = controller
			};
			var drFoot = new CDisplayRow()
			{
				OnClickAction = action,
				OnClickController = controller
			};
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = BankAccountText.AccountName;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = BankAccountText.BankName;
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = BankAccountText.IBAN;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var txxAccount in lstAccounts)
			{
				var strAccount = txxAccount.AccountName;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxAccount.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
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
					CSS = "left hideable",
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
				Content = $"{GeneralText.Count}: {lstAccounts.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 3
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}