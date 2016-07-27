/// <reference path="typings/jquery/jquery.d.ts" />
var m_strPleaseWaitID = "divPleaseWait";
var m_strPleaseWaitTextClass = "PleaseWaitText";
var m_strPleaseWaitPicID = "divPleasePic";
var m_strPleaseWaitPicClass = "PleaseWaitPic";
$(document).ready(addPleaseWait);
function checkHTML5Support() {
    try {
        if (window.clientInformation.appVersion.indexOf('Edge/') > -1) {
            try {
                var test_canvas = document.createElement("canvas");
                return (test_canvas.getContext) ? true : false; //check if object supports getContext() method, a method of the canvas element
            }
            catch (ex) {
                return false;
            }
        }
    }
    catch (ex) { }
    return false;
}
function pleaseWait() {
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
function addPleaseWait() {
    if ($('#' + this.m_strPleaseWaitID).length < 1) {
        $('body').append(pleaseWait());
    }
}
function stopPleaseWait() {
    $('#' + this.m_strPleaseWaitID).hide();
    $('body').removeClass('noScroll');
}
function showPleaseWait() {
    var intHeight;
    $('body').addClass('noScroll');
    addPleaseWait();
    $('#' + this.m_strPleaseWaitID).show();
    if (checkHTML5Support() == false) {
        $('#' + this.m_strPleaseWaitPicID).addClass(this.m_strPleaseWaitPicClass);
    }
    resizePleaseWait();
    $(window).resize(resizePleaseWait);
}
function resizePleaseWait() {
    if ($('#' + this.m_strPleaseWaitID).length > 0) {
        var intTop = $(document).scrollTop() + $('.navbar').outerHeight() + 5;
        $('#' + this.m_strPleaseWaitID).css({
            'top': intTop + 'px',
            'left': '10px'
        });
    }
}
(function () {
    if (window.document.body !== null) {
        window.document.body.onbeforeunload = showPleaseWait;
    }
})();
//# sourceMappingURL=jquery-pleaseWait.js.map