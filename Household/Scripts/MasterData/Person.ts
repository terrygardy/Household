/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Person {
	var m_objPerson: Person;

	interface IPersonOptions extends MasterData.IMasterBaseOptions {
		Surname: string;
		Forename: string;
	}

	export class Person extends MasterData.BaseMasterData {
		Surname: any;
		Forename: any;

		constructor(pv_objOptions: IPersonOptions) {
			super(pv_objOptions);
			this.Surname = ko.observable(pv_objOptions.Surname);
			this.Forename = ko.observable(pv_objOptions.Forename);

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Surname(), this.Forename()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
		}
	}

	export function Save(): void {
		this.m_objPerson.Save();
	}

	export function Delete(): void {
		this.m_objPerson.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strSurname: string, pv_strForename: string): void {
		this.m_objPerson = new Person({ ID: pv_intID, Surname: pv_strSurname, Forename: pv_strForename, BaseAction: pv_strBaseAction });
	}

	export function start() {
		$('#tbxSurname').focus();
	}
}