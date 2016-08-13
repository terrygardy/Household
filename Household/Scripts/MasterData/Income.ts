/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
/// <reference path="Company.ts" />

module Income {
	var m_objIncome: Income;

	interface IIncomeOptions extends MasterData.IMasterDescOptions {
		StartDate: string;
		EndDate: string;
		Interval_ID: number;
		Day_ID: number;
		Payee_ID: number;
		Company_ID: number;
		Amount: number;
	}

	export class Income extends MasterData.BaseDescMasterData {
		StartDate: any;
		EndDate: any;
		Interval_ID: any;
		Day_ID: any;
		Payee_ID: any;
		Company_ID: any;
		Amount: any;

		constructor(pv_objOptions: IIncomeOptions) {
			super(pv_objOptions);
			this.StartDate = ko.observable(pv_objOptions.StartDate);
			this.EndDate = ko.observable(pv_objOptions.EndDate);
			this.Interval_ID = ko.observable(pv_objOptions.Interval_ID);
			this.Day_ID = ko.observable(pv_objOptions.Day_ID);
			this.Payee_ID = ko.observable(pv_objOptions.Payee_ID);
			this.Company_ID = ko.observable(pv_objOptions.Company_ID);
			this.Amount = ko.observable(pv_objOptions.Amount);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Income: this }), [this.StartDate(), this.EndDate(), this.Amount() + ' €', getCurrentCompanyText()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
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
		this.m_objIncome = new Income({
			ID: pv_intID,
			Description: pv_strDescription,
			BaseAction: pv_strBaseAction,
			StartDate: pv_strStartDate,
			EndDate: pv_strEndDate,
			Interval_ID: pv_intInterval,
			Day_ID: pv_intDay,
			Payee_ID: pv_intPayee,
			Company_ID: pv_intCompany,
			Amount: pv_decAmount
		});
	}

	function getCurrentCompanyText(): string {
		return $('#cboCompany option:selected').text();
	}

	export function start() {
		$('#tbxStartDate').focus();
	}
}