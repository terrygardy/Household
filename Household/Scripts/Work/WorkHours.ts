/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />

module WorkDay {
	var m_objWorkDay: WorkDay;

	interface IWorkDayOptions extends MasterData.IMasterBaseOptions {
		WorkDay: string;
		Begin: string;
		End: string;
		BreakDuration: number;
	}

	export class WorkDay extends MasterData.BaseMasterData {
		WorkDay: any;
		Begin: any;
		End: any;
		BreakDuration: any;

		constructor(pv_objOptions: IWorkDayOptions) {
			super(pv_objOptions);
			this.WorkDay = ko.observable(pv_objOptions.WorkDay);
			this.Begin = ko.observable(pv_objOptions.Begin);
			this.End = ko.observable(pv_objOptions.End);
			this.BreakDuration = ko.observable(pv_objOptions.BreakDuration);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ WorkDay: this }), [this.WorkDay(), this.Begin(), this.End(), this.BreakDuration()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
		}
	}

	export function Save(): void {
		this.m_objWorkDay.Save();
	}

	export function Delete(): void {
		this.m_objWorkDay.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strWorkDay: string, pv_strBegin: string, pv_strEnd: string,
		pv_decBreakDuration: number): void {
		this.m_objWorkDay = new WorkDay({
			ID: pv_intID,
			WorkDay: pv_strWorkDay,
			Begin: pv_strBegin,
			End: pv_strEnd,
			BreakDuration: pv_decBreakDuration,
			BaseAction: pv_strBaseAction
		});
	}

	export function start() {
		$('#tbxWorkDay').focus();
	}
}