/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="../jquery-pleaseWait.ts" />
/// <reference path="../validation.ts" />

module MasterData {
	var m_strTableId: string = "tblDisplay";
	var m_strTableSelector: string = "#" + m_strTableId;
	export var OnClickAdd: string = '';

	export class Return {
		Message: string;
		ID: number;
	}

	export function deleteRow(pv_intID: number) {
		var spFooter: JQuery;

		$(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').remove();

		updateFooterText(-1);
	}

	export function updateFooterText(pv_intDifference: number): void {
		var spFooter: JQuery = $('#spDisplayFoot');

		if (spFooter.length > 0) {
			var intCount: number = $(m_strTableSelector + ' tbody tr').length;

			spFooter.text("Count: " + intCount);
		}
	}

	export function updateRow(pv_intID: number, pv_arrParams: Array<string>) {
		var arrChildren: JQuery = $(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').children();

		if (arrChildren.length < 1) {
			var strTr: string = '<tr id="' + pv_intID.toString() + '"';

			if (this.OnClickAdd.length > 0) { strTr += ' class="clickable" onclick="Common.LoadSubContent(\'' + this.OnClickAdd + '/' + pv_intID.toString() + '\');Common.showSubContent();" '; }

			strTr += '>';

			for (var i: number = 0; i < pv_arrParams.length; i++) {
				strTr += "<td></td>";
			}

			strTr += "</tr>";

			if ($(m_strTableSelector + ' tbody').length < 1) { $('<tbody></tbody>').insertAfter($(m_strTableSelector + ' thead')); }

			$(m_strTableSelector + ' tbody').append(strTr);

			arrChildren = $(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').children();

			updateFooterText(1);
		}

		for (var i: number = 0; i < pv_arrParams.length; i++) {
			if (arrChildren.length >= i) {
				$(arrChildren[i]).text(pv_arrParams[i]);
			}
		}
	}

	export function deleteMasterRecord(pv_strBaseURL: string, pv_intID: number): void {
		showPleaseWait();

		try {
			var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strBaseURL + '/Delete/' + pv_intID.toString(), Helpers.HttpRequests.GetContentTypeForm());
			var strReturn: string;

			objRequest.send();
			strReturn = objRequest.response;

			if (strReturn.length > 0) {
				alert(strReturn);
			}
			else {
				MasterData.deleteRow(pv_intID);
				Common.hideSubContent();
			}
		}
		catch (ex) { }

		stopPleaseWait();
	}

	export function saveMasterRecord(pv_strBaseURL: string, pv_objData: any, pv_arrDisplayCells: Array<string>): void {
		var strReturn: string = saveMasterRecordWithMessage(pv_strBaseURL, pv_objData, pv_arrDisplayCells, true);

		if (strReturn.length > 0) {
			alert(strReturn);
		}
	}

	export function saveMasterRecordWithMessage(pv_strBaseURL: string, pv_objData: any, pv_arrDisplayCells: Array<string>, pv_blnClose: boolean): string {
		var strValidate: string = MasterData.isFormValid();

		if (strValidate !== '') {
			return strValidate;
		}
		else {
			showPleaseWait();

			try {
				var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strBaseURL + '/Save/', Helpers.HttpRequests.GetContentTypeJson());
				var objReturn: MasterData.Return;
				
				objRequest.send(pv_objData);
				objReturn = JSON.parse(objRequest.response);

				if (objReturn.Message.length > 0) {
					return objReturn.Message;
				}
				else {
					MasterData.updateRow(objReturn.ID, pv_arrDisplayCells);

					if (pv_blnClose === true) { $('#btnClose').click(); }
				}
			} catch (ex) {
				return 'Save was unsuccessful: ' + ex;
			}
			finally {
				stopPleaseWait();
			}

			return '';
		}
	}

	export function isFormValid(): string {
		if (MasterData.isValid('form') === true) {
			return '';
		}
		else {
			return 'Some or all of your entries are invalid.';
		}
	}

	export function isValid(pv_strSelector: string): boolean {
		return $(pv_strSelector).valid();
	}

	export function start() {
		var olBC: JQuery = $('form').children('#olBC_MasterData');

		$(':text').each(function () {
			$(this).change(function () {
				$(this).val($(this).val().trim());
			});
		});

		$('input').each(function () {
			$(this).keyup(function (e) {
				if (e.keyCode == 13) {
					$('#btnSave').click();
				} else {
					if (e.keyCode == 27) {
						$('#btnClose').click();
					}
				}
			});
		});

		if ((olBC.length > 0) && (olBC.children().length < 1)) { olBC.remove(); }

		Validation.validateForm();
	}
}