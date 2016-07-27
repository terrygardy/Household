/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />
var Purchase;
(function (Purchase_1) {
    var m_objPurchase;
    var Purchase = (function () {
        function Purchase(pv_intID, pv_strOccurrence, pv_lngShop, pv_lngPayer, pv_decAmount, pv_strDescription, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.Occurrence = ko.observable(pv_strOccurrence);
            this.Shop_ID = ko.observable(pv_lngShop);
            this.Payer_ID = ko.observable(pv_lngPayer);
            this.Amount = ko.observable(pv_decAmount);
            this.Description = ko.observable(pv_strDescription);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Purchase.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Purchase: this }), [this.Occurrence(), getCurrentPayerText(), getCurrentShopText(), this.Amount() + ' €']);
        };
        Purchase.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Purchase;
    }());
    Purchase_1.Purchase = Purchase;
    function Save() {
        this.m_objPurchase.Save();
    }
    Purchase_1.Save = Save;
    function Delete() {
        this.m_objPurchase.Delete();
    }
    Purchase_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strOccurrence, pv_lngShop, pv_lngPayer, pv_decAmount, pv_strDescription) {
        this.m_objPurchase = new Purchase(pv_intID, pv_strOccurrence, pv_lngShop, pv_lngPayer, pv_decAmount, pv_strDescription, pv_strBaseAction);
    }
    Purchase_1.Fill = Fill;
    function getCurrentShopText() {
        return $('#cboShop option:selected').text();
    }
    function getCurrentPayerText() {
        var strBankAccount = $('#cboBankAccount option:selected').text();
        return strBankAccount.substring(0, strBankAccount.indexOf(":")).trim();
    }
    function start() {
        $('#tbxDate').focus();
    }
    Purchase_1.start = start;
})(Purchase || (Purchase = {}));
//# sourceMappingURL=Purchase.js.map