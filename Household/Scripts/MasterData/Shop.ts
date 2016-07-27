/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Shop {
	var m_objShop: Shop;

	export class Shop {
		ID: any;
		Name: any;
		Description: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strName: string, pv_strDescription: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.Name = ko.observable(pv_strName);
			this.Description = ko.observable(pv_strDescription);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ "Shop": this }), [this.Name(), this.Description()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function Save(): void {
		this.m_objShop.Save();
	}

	export function Delete(): void {
		this.m_objShop.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strName: string, pv_strDescription: string): void {
		this.m_objShop = new Shop(pv_intID, pv_strName, pv_strDescription, pv_strBaseAction);
	}

	export function start() {
		$('#tbxName').focus();
	}
}