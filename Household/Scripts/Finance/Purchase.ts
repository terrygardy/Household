/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />

module Purchase {
	var m_objPurchase: Purchase;

	export class Purchase {
		ID: any;
		Occurrence: any;
		Shop_ID: any;
		Payer_ID: any;
		Amount: any;
		Description: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strOccurrence: string, pv_lngShop: number, pv_lngPayer: number, pv_decAmount: number,
			pv_strDescription: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.Occurrence = ko.observable(pv_strOccurrence);
			this.Shop_ID = ko.observable(pv_lngShop);
			this.Payer_ID = ko.observable(pv_lngPayer);
			this.Amount = ko.observable(pv_decAmount);
			this.Description = ko.observable(pv_strDescription);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Purchase: this }), [this.Occurrence(), getCurrentPayerText(), getCurrentShopText(), this.Amount() + ' €']);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
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
		this.m_objPurchase = new Purchase(pv_intID, pv_strOccurrence, pv_lngShop, pv_lngPayer, pv_decAmount, pv_strDescription, pv_strBaseAction);
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