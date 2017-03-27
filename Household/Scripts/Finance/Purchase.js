/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Purchase;
(function (Purchase_1) {
    var m_objPurchase;
    var Purchase = (function (_super) {
        __extends(Purchase, _super);
        function Purchase(pv_objOptions) {
            var _this = _super.call(this, pv_objOptions) || this;
            _this.Occurrence = ko.observable(pv_objOptions.Occurrence);
            _this.Shop_ID = ko.observable(pv_objOptions.Shop_ID);
            _this.Payer_ID = ko.observable(pv_objOptions.Payer_ID);
            _this.Amount = ko.observable(pv_objOptions.Amount);
            ko.applyBindings(_this);
            return _this;
        }
        Purchase.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), null);
            Finance.updateBankBalance();
        };
        Purchase.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, true);
            Finance.updateBankBalance();
        };
        return Purchase;
    }(MasterData.BaseDescMasterData));
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
        this.m_objPurchase = new Purchase({
            ID: pv_intID,
            Occurrence: pv_strOccurrence,
            Shop_ID: pv_lngShop,
            Payer_ID: pv_lngPayer,
            Amount: pv_decAmount,
            Description: pv_strDescription,
            BaseAction: pv_strBaseAction
        });
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