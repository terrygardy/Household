/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
/// <reference path="Company.ts" />

module Income {
	var m_objIncome: Income;

	export class Income {
		ID: any;
		StartDate: any;
		EndDate: any;
		Interval_ID: any;
		Day_ID: any;
		Payee_ID: any;
		Company_ID: any;
		Amount: any;
		Description: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strStartDate: string, pv_strEndDate: string, pv_intInterval: number, pv_intDay: number, pv_intPayee: number,
			pv_intCompany: number, pv_decAmount: number, pv_strDescription: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.StartDate = ko.observable(pv_strStartDate);
			this.EndDate = ko.observable(pv_strEndDate);
			this.Interval_ID = ko.observable(pv_intInterval);
			this.Day_ID = ko.observable(pv_intDay);
			this.Payee_ID = ko.observable(pv_intPayee);
			this.Company_ID = ko.observable(pv_intCompany);
			this.Amount = ko.observable(pv_decAmount);
			this.Description = ko.observable(pv_strDescription);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Income: this }), [this.StartDate(), this.EndDate(), this.Amount() + ' €', getCurrentCompanyText()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function Save(): void {
		this.m_objIncome.Save();
	}

	export function Delete(): void {
		this.m_objIncome.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strStartDate: string, pv_strEndDate: string, pv_intInterval: number,
		pv_intDay: number, pv_intPayee: number, pv_intCompany: number, pv_decAmount: number, pv_strDescription: string): void {
		this.m_objIncome = new Income(pv_intID, pv_strStartDate, pv_strEndDate, pv_intInterval, pv_intDay, pv_intPayee, pv_intCompany,
			pv_decAmount, pv_strDescription, pv_strBaseAction);
	}

	function getCurrentCompanyText(): string {
		return $('#cboCompany option:selected').text();
	}

	export function start() {
		$('#tbxStartDate').focus();
	}
}