/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />

module Expense {
	var m_objExpense: Expense;

	export class Expense {
		ID: any;
		StartDate: any;
		EndDate: any;
		Company_ID: any;
		BankAccount_ID: any;
		PaymentDay_ID: any;
		Interval_ID: any;
		Amount: any;
		Description: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strStartDate: string, pv_strEndDate: string, pv_lngCompany: number, pv_lngBankAccount: number,
			pv_lngPaymentDay: number, pv_lngInterval: number, pv_decAmount: number, pv_strDescription: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.StartDate = ko.observable(pv_strStartDate);
			this.EndDate = ko.observable(pv_strEndDate);
			this.Company_ID = ko.observable(pv_lngCompany);
			this.BankAccount_ID = ko.observable(pv_lngBankAccount);
			this.PaymentDay_ID = ko.observable(pv_lngPaymentDay);
			this.Interval_ID = ko.observable(pv_lngInterval);
			this.Amount = ko.observable(pv_decAmount);
			this.Description = ko.observable(pv_strDescription);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Expense: this }), [this.StartDate(), this.EndDate(), getCurrentBankAccountText(), getCurrentCompanyText(), this.Amount() + ' €']);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
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
		this.m_objExpense = new Expense(pv_intID, pv_strStartDate, pv_strEndDate, pv_lngCompany, pv_lngBankAccount, pv_lngPaymentDay, pv_lngInterval,
			pv_decAmount, pv_strDescription, pv_strBaseAction);
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