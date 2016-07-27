/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Interval {
	var m_objInterval: Interval;

	export class Interval {
		ID: any;
		Name: any;
		BaseAction: any;

		constructor(pv_intID: number, pv_strName: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.Name = ko.observable(pv_strName);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Interval: this }), [this.Name()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function Save(): void {
		this.m_objInterval.Save();
	}

	export function Delete(): void {
		this.m_objInterval.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strName: string): void {
		this.m_objInterval = new Interval(pv_intID, pv_strName, pv_strBaseAction);
	}

	export function start() {
		$('#tbxName').focus();
	}
}