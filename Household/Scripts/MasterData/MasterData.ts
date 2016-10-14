/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="../jquery-pleaseWait.ts" />
/// <reference path="../validation.ts" />

module MasterData {
	/**
	 * Internals
	 */

	var m_strTableId: string = "tblDisplay";
	var m_strTableSelector: string = "#" + m_strTableId;

	class Return {
		Message: string;
		ID: number;
	}

	function toggleHideableColumns() {
		$("#tblDisplay").removeClass("w90");

		var windowWidth = $(window).width();
		var tableWidth = $("#tblDisplay").width() + 10;

		if (tableWidth > windowWidth) {
			$("th.hideable").each(function () {
				$(this).hide();
			});
			$("td.hideable").each(function () { $(this).hide(); });
		}
		else {
			tableWidth += $("#tblDisplay thead tr > th").width();

			if (tableWidth < windowWidth) {
				$("th.hideable").each(function () {
					$(this).show();
				});
				$("td.hideable").each(function () { $(this).show(); });
			}
		}

		$("#tblDisplay").addClass("w90");
	}

	/**
	 * Exports
	 */

	export var OnClickAdd: string = '';

	export interface IMasterBaseOptions {
		ID: any;
		BaseAction: string;
	}

	export interface IMasterNameOptions extends IMasterBaseOptions {
		Name: any;
	}

	export interface IMasterDescOptions extends IMasterBaseOptions {
		Description: any;
	}

	export interface IMasterNameDescOptions extends IMasterNameOptions, IMasterDescOptions {
	}

	export class BaseMasterData {
		ID: any;
		BaseAction: string;

		constructor(pv_objOptions: IMasterBaseOptions) {
			this.ID = ko.observable(pv_objOptions.ID);
			this.BaseAction = pv_objOptions.BaseAction;
		}
	}

	export class BaseNameMasterData extends BaseMasterData {
		Name: any;

		constructor(pv_objOptions: IMasterNameOptions) {
			super(pv_objOptions);
			this.Name = ko.observable(pv_objOptions.Name);
		}
	}

	export class BaseNameDescMasterData extends BaseNameMasterData {
		Description: any;

		constructor(pv_objOptions: IMasterNameDescOptions) {
			super(pv_objOptions);
			this.Description = ko.observable(pv_objOptions.Description);
		}
	}

	export class BaseDescMasterData extends BaseMasterData {
		Description: any;

		constructor(pv_objOptions: IMasterDescOptions) {
			super(pv_objOptions);
			this.Description = ko.observable(pv_objOptions.Description);
		}
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

	export function replaceBodyRow(pv_strBaseURL: string, pv_intID: number): void {
		$.ajax({
			method: "POST",
			url: pv_strBaseURL + "/GetTableBodyRow",
			data: { id: pv_intID },
			success: (data) => {
				var row = $('#' + pv_intID);

				if (row.length > 0) {
					$(data).insertAfter(row);
					row.remove();
				}
				else {
					$(data).insertAfter($(m_strTableSelector + " tbody tr:last"));
				}

				MasterData.replaceTableFooter(pv_strBaseURL);
			}
		});
	}

	export function replaceTableFooter(pv_strBaseURL: string): void {
		$.ajax({
			method: "POST",
			url: pv_strBaseURL + "/GetTableFooter",
			data: {
				search: Common.GetSearchObject()
			},
			success: (data) => {
				var footer = $(m_strTableSelector + " tfoot");
				footer.empty();
				footer.html(data);
			}
		});
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

	export function deleteMasterRecord(pv_objOptions: IMasterBaseOptions, replaceFooter: boolean): void {
		showPleaseWait();

		try {
			var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_objOptions.BaseAction + '/Delete/' + pv_objOptions.ID.toString(), Helpers.HttpRequests.GetContentTypeForm());
			var strReturn: string;

			objRequest.send();
			strReturn = objRequest.response;

			if (strReturn.length > 0) {
				alert(strReturn);
			}
			else {
				MasterData.deleteRow(pv_objOptions.ID);

				if (replaceFooter === true) {
					MasterData.replaceTableFooter(pv_objOptions.BaseAction);
				}
				
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
				var objReturn: Return;

				objRequest.send(pv_objData);
				objReturn = JSON.parse(objRequest.response);

				if (objReturn.Message.length > 0) {
					return objReturn.Message;
				}
				else {
					if (pv_arrDisplayCells !== null) {
						MasterData.updateRow(objReturn.ID, pv_arrDisplayCells);
					}
					else {
						MasterData.replaceBodyRow(pv_strBaseURL, objReturn.ID);
					}

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

		$('input:text:not(textarea)').each(function () {
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

	export function setupHideables(): void {
		toggleHideableColumns();

		$(window).resize(toggleHideableColumns);
	}
}