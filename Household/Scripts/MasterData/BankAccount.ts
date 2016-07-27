/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module BankAccount {
	var m_objBankAccount: BankAccount;

	export class BankAccount {
		ID: any;
		AccountName: any;
		BankName: any;
		IBAN: any;
		BIC: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strAccountName: string, pv_strBankName: string, pv_strIBAN: string, pv_strBIC: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.AccountName = ko.observable(pv_strAccountName);
			this.BankName = ko.observable(pv_strBankName);
			this.IBAN = ko.observable(pv_strIBAN);
			this.BIC = ko.observable(pv_strBIC);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			this.IBAN(this.IBAN().toString().toUpperCase());

			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ BankAccount: this }), [this.AccountName(), this.BankName(), this.IBAN()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function Save(): void {
		this.m_objBankAccount.Save();
	}

	export function Delete(): void {
		this.m_objBankAccount.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strAccountName: string, pv_strBankName: string, pv_strIBAN: string, pv_strBIC: string): void {
		this.m_objBankAccount = new BankAccount(pv_intID, pv_strAccountName, pv_strBankName, formatIBAN(pv_strIBAN), pv_strBIC, pv_strBaseAction);
	}

	export function formatIBAN(pv_strIBAN: string) {
		var i: number = 4;

		pv_strIBAN = pv_strIBAN.replace(/-/g, '').replace(/ /g, '').toUpperCase();

		while (i < pv_strIBAN.length) {
			pv_strIBAN = Common.AddCharacterToText(pv_strIBAN, i, '-');
			i += 5;
		}

		return pv_strIBAN.substr(0, (pv_strIBAN.length < 27 ? pv_strIBAN.length : 27));
	}

	export function start() {
		$('#tbxIBAN').keyup(keyUpIBAN);
		$('#tbxAccountName').focus();
	}

	function keyUpIBAN(e: KeyboardEvent) {
		if ((e.which > 47) && (e.which < 90)) {
			var objTextBox: HTMLInputElement = (<HTMLInputElement>this);
			var strValue: string = objTextBox.value;

			strValue = formatIBAN(strValue);

			objTextBox.value = strValue;
		}
	}
}