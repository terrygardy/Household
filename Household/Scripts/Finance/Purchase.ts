/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />

module Purchase {
	var m_objPurchase: Purchase;

	interface IPurchaseOptions extends MasterData.IMasterDescOptions {
		Occurrence: string;
		Shop_ID: number;
		Payer_ID: number;
		Amount: number;
	}

	export class Purchase extends MasterData.BaseDescMasterData {
		Occurrence: any;
		Shop_ID: any;
		Payer_ID: any;
		Amount: any;

		constructor(pv_objOptions: IPurchaseOptions) {
			super(pv_objOptions);
			this.Occurrence = ko.observable(pv_objOptions.Occurrence);
			this.Shop_ID = ko.observable(pv_objOptions.Shop_ID);
			this.Payer_ID = ko.observable(pv_objOptions.Payer_ID);
			this.Amount = ko.observable(pv_objOptions.Amount);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), null);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, true);
		}
	}

	export function Save(): void {
		this.m_objPurchase.Save();
	}

	export function Delete(): void {
		this.m_objPurchase.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strOccurrence: string, pv_lngShop: number,
		pv_lngPayer: number, pv_decAmount: number, pv_strDescription: string): void {
		this.m_objPurchase = new Purchase({
			ID: pv_intID,
			Occurrence: pv_strOccurrence,
			Shop_ID: pv_lngShop,
			Payer_ID: pv_lngPayer,
			Amount: pv_decAmount,
			Description: pv_strDescription,
			BaseAction: pv_strBaseAction
		});
	}

	function getCurrentShopText(): string {
		return $('#cboShop option:selected').text();
	}

	function getCurrentPayerText(): string {
		var strBankAccount: string = $('#cboBankAccount option:selected').text();

		return strBankAccount.substring(0, strBankAccount.indexOf(":")).trim();
	}

	export function start() {
		$('#tbxDate').focus();
	}
}