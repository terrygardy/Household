/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="MasterData.ts" />

module BankAccount {
	var m_objBankAccount: BankAccount;

	interface IBankAccountOptions extends MasterData.IMasterBaseOptions {
		AccountName: string;
		BankName: string;
		IBAN: string;
		BIC: string;
	}

	export class BankAccount extends MasterData.BaseMasterData {
		AccountName: any;
		BankName: any;
		IBAN: any;
		BIC: any;

		constructor(pv_objOptions: IBankAccountOptions) {
			super(pv_objOptions);
			this.AccountName = ko.observable(pv_objOptions.AccountName);
			this.BankName = ko.observable(pv_objOptions.BankName);
			this.IBAN = ko.observable(pv_objOptions.IBAN);
			this.BIC = ko.observable(pv_objOptions.BIC);

			ko.applyBindings(this);
		}

		Save(): void {
			this.IBAN(this.IBAN().toString().toUpperCase());

			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.AccountName(), this.BankName(), this.IBAN()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, false);
		}
	}

	export function Save(): void {
		this.m_objBankAccount.Save();
	}

	export function Delete(): void {
		this.m_objBankAccount.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strAccountName: string, pv_strBankName: string, pv_strIBAN: string, pv_strBIC: string): void {
		this.m_objBankAccount = new BankAccount({
			ID: pv_intID,
			AccountName: pv_strAccountName,
			BankName: pv_strBankName,
			IBAN: formatIBAN(pv_strIBAN),
			BIC: pv_strBIC,
			BaseAction: pv_strBaseAction
		});
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