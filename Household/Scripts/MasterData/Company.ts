/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Company {
	var m_objCompany: Company;

	export class Company extends MasterData.BaseNameDescMasterData {

		constructor(pv_objOptions: MasterData.IMasterNameDescOptions) {
			super(pv_objOptions);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Name(), this.Description()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
		}
	}

	export function Save(): void {
		this.m_objCompany.Save();
	}

	export function Delete(): void {
		this.m_objCompany.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strName: string, pv_strDescription: string): void {
		this.m_objCompany = new Company({
			ID: pv_intID,
			Name: pv_strName,
			Description: pv_strDescription,
			BaseAction: pv_strBaseAction
		});
	}

	export function start() {
		$('#tbxName').focus();
	}

	export function GetNameByID(pv_intID: number): string {
		var strName: string = '';

		try {
			var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST('/Company/GetNameByID/' + pv_intID.toString(), Helpers.HttpRequests.GetContentTypeForm());

			objRequest.send();

			strName = objRequest.response;
		} catch (ex) {
			strName = 'unknown';
		}

		return strName;
	}
}