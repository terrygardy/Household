/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../Helpers/HTTPRequest.ts" />
/// <reference path="../jquery-pleaseWait.ts" />
var Finance;
(function (Finance) {
    var Shop = (function () {
        function Shop() {
        }
        return Shop;
    }());
    var Purchase = (function () {
        function Purchase() {
        }
        return Purchase;
    }());
    function updateBankBalance() {
        var jqBreadCrumb = $(".breadcrumb");
        if (jqBreadCrumb.length > 0) {
            try {
                jqBreadCrumb = $(jqBreadCrumb[0]);
                var jqBankBalance_1 = jqBreadCrumb.children("li.bankBalance");
                if (jqBankBalance_1.length < 1) {
                    jqBreadCrumb.append("<li class=\"bankBalance fRight\"></li>");
                    jqBankBalance_1 = jqBreadCrumb.children("li.bankBalance");
                }
                var request_1 = Helpers.HttpRequests.CreateAsyncRequestHandlerPOST("/Banking/GetCurrentBankBalance", Helpers.HttpRequests.GetContentTypeForm());
                request_1.onload = function (e) {
                    jqBankBalance_1.html(request_1.responseText);
                };
                request_1.send(null);
            }
            catch (ex) {
                alert(ex);
            }
        }
    }
    Finance.updateBankBalance = updateBankBalance;
})(Finance || (Finance = {}));
$(Finance.updateBankBalance);
//# sourceMappingURL=Finance.js.map