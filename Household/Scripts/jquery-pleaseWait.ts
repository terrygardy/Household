/// <reference path="typings/jquery/jquery.d.ts" />

var m_strPleaseWaitID: string = "divPleaseWait";
var m_strPleaseWaitTextClass: string = "PleaseWaitText";
var m_strPleaseWaitPicID: string = "divPleasePic";
var m_strPleaseWaitPicClass: string = "PleaseWaitPic";

$(document).ready(addPleaseWait);

function checkHTML5Support(): boolean {
	try {
		if (window.clientInformation.appVersion.indexOf('Edge/') > -1) {
			try {
				var test_canvas: HTMLCanvasElement = document.createElement("canvas");

				return (test_canvas.getContext) ? true : false; //check if object supports getContext() method, a method of the canvas element
			} catch (ex) {
				return false;
			}
		}
	} catch (ex) { }

	return false;
}

function pleaseWait(): string {

	if (checkHTML5Support() == true) {
		return '<div id="' + this.m_strPleaseWaitID + '" style="display: none; z-index: 40; width: 118px;">' +
			'<div class="' + this.m_strPleaseWaitTextClass + ' fLeft" style="padding-bottom: 0px; line-height: 30px;">Please Wait</div>' +
			'<progress id="' + this.m_strPleaseWaitPicID + '" class="fLeft" style="width: 90%;"></div><div class="fClear"></div>' +
			'</div>';
	}

	return '<div id="' + this.m_strPleaseWaitID + '" style="display: none; z-index: 40;">' +
		'<div class="' + this.m_strPleaseWaitTextClass + '">Please Wait</div>' +
		'<div id="' + this.m_strPleaseWaitPicID + '"></div>' +
		'</div>';
}

function addPleaseWait(): void {
	if ($('#' + this.m_strPleaseWaitID).length < 1) {
		$('body').append(pleaseWait());
	}
}

function stopPleaseWait(): void {
	$('#' + this.m_strPleaseWaitID).hide();
	$('body').removeClass('noScroll');
}

function showPleaseWait(): void {

	var intHeight: number;

	$('body').addClass('noScroll');

	addPleaseWait();

	$('#' + this.m_strPleaseWaitID).show();

	if (checkHTML5Support() == false) {
		$('#' + this.m_strPleaseWaitPicID).addClass(this.m_strPleaseWaitPicClass);
	}

	resizePleaseWait();
	$(window).resize(resizePleaseWait);
}

function resizePleaseWait(): void {
	if ($('#' + this.m_strPleaseWaitID).length > 0) {
		var intTop: number = $(document).scrollTop() + $('.navbar').outerHeight() + 5;

		$('#' + this.m_strPleaseWaitID).css({
			'top': intTop + 'px',
			'left': '10px'
		});
	}
}

(function () {
	if (window.document.body !== null) {
		(<HTMLBodyElement>window.document.body).onbeforeunload = showPleaseWait;
	}
})();