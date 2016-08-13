/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />

module Expense {
	var m_objExpense: Expense;

	interface IExpenseOptions extends MasterData.IMasterDescOptions {
		StartDate: string;
		EndDate: string;
		Company_ID: number;
		BankAccount_ID: number;
		PaymentDay_ID: number;
		Interval_ID: number;
		Amount: number;
	}

	export class Expense extends MasterData.BaseMasterData {
		StartDate: any;
		EndDate: any;
		Company_ID: any;
		BankAccount_ID: any;
		PaymentDay_ID: any;
		Interval_ID: any;
		Amount: any;
		Description: any;
		BaseAction: string;

		constructor(pv_objOptions: IExpenseOptions) {
			super(pv_objOptions);
			this.StartDate = ko.observable(pv_objOptions.StartDate);
			this.EndDate = ko.observable(pv_objOptions.EndDate);
			this.Company_ID = ko.observable(pv_objOptions.Company_ID);
			this.BankAccount_ID = ko.observable(pv_objOptions.BankAccount_ID);
			this.PaymentDay_ID = ko.observable(pv_objOptions.PaymentDay_ID);
			this.Interval_ID = ko.observable(pv_objOptions.Interval_ID);
			this.Amount = ko.observable(pv_objOptions.Amount);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.StartDate(), this.EndDate(), getCurrentBankAccountText(), getCurrentCompanyText(), this.Amount() + ' €']);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
		}
	}

	export function Save(): void {
		this.m_objExpense.Save();
	}

	export function Delete(): void {
		this.m_objExpense.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strStartDate: string, pv_strEndDate: string, pv_lngCompany: number, pv_lngBankAccount: number,
		pv_lngPaymentDay: number, pv_lngInterval: number, pv_decAmount: number, pv_strDescription: string): void {
		this.m_objExpense = new Expense({
			ID: pv_intID,
			StartDate: pv_strStartDate,
			EndDate: pv_strEndDate,
			Company_ID: pv_lngCompany,
			BankAccount_ID: pv_lngBankAccount,
			PaymentDay_ID: pv_lngPaymentDay,
			Interval_ID: pv_lngInterval,
			Amount: pv_decAmount,
			Description: pv_strDescription,
			BaseAction: pv_strBaseAction
		});
	}

	function getCurrentCompanyText(): string {
		return $('#cboCompany option:selected').text();
	}

	function getCurrentBankAccountText(): string {
		var strBankAccount: string = $('#cboBankAccount option:selected').text();

		return strBankAccount.substring(0, strBankAccount.indexOf(":")).trim();
	}

	export function start() {
		$('#tbxStartDate').focus();
	}
}