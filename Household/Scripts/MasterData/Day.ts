/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />

module Day {
	var m_objDay: Day;

	export class Day {
		ID: any;
		Day: any;
		BaseAction: string;

		constructor(pv_intID: number, pv_intDay: number, pv_strBaseAction: string) {
			this.ID = ko.observable(pv_intID);
			this.Day = ko.observable(pv_intDay);
			this.BaseAction = pv_strBaseAction;

			ko.applyBindings(this);
		}

		Save(pv_blnClose: boolean): string {
			return MasterData.saveMasterRecordWithMessage(this.BaseAction, ko.toJSON({ Day: this }), [this.Day()], pv_blnClose);
		}

		Delete(): void {
			MasterData.deleteMasterRecord(this.BaseAction, this.ID());
		}
	}

	export function SaveSingle(): void {
		if (m_objDay == null) {
			alert('The current day has not been set');
		}
		else {
			var strReturn: string = m_objDay.Save(true);

			if (strReturn.length > 0) { alert(strReturn); }
		}
	}

	export function Save(): void {
		if ($('#divMultiple').hasClass('invisible') == true) {
			SaveSingle();
		}
		else {
			var intStart: number = Number($('#tbxStart').val());
			var intEnd: number = Number($('#tbxEnd').val());

			if (intStart < 1) { intStart = 1; }

			if (intEnd < 1) { intEnd = 1; }

			if (intEnd < intStart) {
				alert('The entered time window is invalid');
			} else {
				var strBaseAction: string = m_objDay.BaseAction;
				var strMessage: string = '';

				for (var i: number = intStart; i <= intEnd; i++) {
					var strReturn: string;

					Fill(strBaseAction, 0, i);
					strReturn = m_objDay.Save((i == intEnd));

					if ((strReturn.length > 0) && (strMessage.indexOf(strReturn) < 0)) {
						strMessage += '\n' + strReturn;
					}
				}

				if (strMessage.length > 0) { alert(strMessage); }
			}
		}
	}

	export function Delete(): void {
		m_objDay.Delete();
	}

	export function ShowMultiple(): void {
		$('#divMultiple').removeClass('invisible');
		$('#divInput').addClass('invisible');
	}

	export function HideMultiple(): void {
		$('#divMultiple').addClass('invisible');
		$('#divInput').removeClass('invisible');
	}

	export function Fill(pv_strBaseAction: string, pv_intID: number, pv_intDay: number): void {
		if (m_objDay == null) {
			m_objDay = new Day(pv_intID, pv_intDay, pv_strBaseAction);
		} else {
			m_objDay.BaseAction = pv_strBaseAction;
			m_objDay.Day(pv_intDay);
			m_objDay.ID(pv_intID);
		}
	}

	export function start() {
		$('#tbxDay').focus();
	}
}