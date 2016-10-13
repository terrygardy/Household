/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Shop {
	var m_objShop: Shop;

	export class Shop extends MasterData.BaseNameDescMasterData {

		constructor(pv_objOptions: MasterData.IMasterNameDescOptions) {
			super(pv_objOptions);
			
			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Name(), this.Description()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ ID: this.ID(), BaseAction: this.BaseAction }, false);
		}
	}

	export function Save(): void {
		this.m_objShop.Save();
	}

	export function Delete(): void {
		this.m_objShop.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strName: string, pv_strDescription: string): void {
		this.m_objShop = new Shop({
			ID: pv_intID,
			BaseAction: pv_strBaseAction,
			Name: pv_strName,
			Description: pv_strDescription
		});
	}

	export function start() {
		$('#tbxName').focus();
	}
}