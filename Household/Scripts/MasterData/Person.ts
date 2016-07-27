/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Person {
	var m_objPerson: Person;

	export class Person {
		ID: any;
		Surname: any;
		Forename: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_strSurname: string, pv_strForename: string, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.Surname = ko.observable(pv_strSurname);
			this.Forename = ko.observable(pv_strForename);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(): void {
			MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Person: this }), [this.Surname(), this.Forename()]);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function Save(): void {
		this.m_objPerson.Save();
	}

	export function Delete(): void {
		this.m_objPerson.Delete();
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_strSurname: string, pv_strForename: string): void {
		this.m_objPerson = new Person(pv_intID, pv_strSurname, pv_strForename, pv_strBaseAction);
	}

	export function start() {
		$('#tbxSurname').focus();
	}
}