/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Interval {
	var m_objInterval: Interval;

	export class Interval extends MasterData.BaseNameMasterData{

		constructor(pv_objOptions: MasterData.IMasterNameOptions) {
			super(pv_objOptions);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Interval: this }), [this.Name()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
		}
	}

	export function Save(): void {
		this.m_objInterval.Save();
	}

	export function Delete(): void {
		this.m_objInterval.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strName: string): void {
		this.m_objInterval = new Interval({ ID: pv_intID, Name: pv_strName, BaseAction: pv_strBaseAction });
	}

	export function start() {
		$('#tbxName').focus();
	}
}