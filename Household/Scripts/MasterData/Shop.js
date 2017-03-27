/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Shop;
(function (Shop_1) {
    var m_objShop;
    var Shop = (function (_super) {
        __extends(Shop, _super);
        function Shop(pv_objOptions) {
            var _this = _super.call(this, pv_objOptions) || this;
            ko.applyBindings(_this);
            return _this;
        }
        Shop.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Name(), this.Description()]);
        };
        Shop.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ ID: this.ID(), BaseAction: this.BaseAction }, false);
        };
        return Shop;
    }(MasterData.BaseNameDescMasterData));
    Shop_1.Shop = Shop;
    function Save() {
        this.m_objShop.Save();
    }
    Shop_1.Save = Save;
    function Delete() {
        this.m_objShop.Delete();
    }
    Shop_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strName, pv_strDescription) {
        this.m_objShop = new Shop({
            ID: pv_intID,
            BaseAction: pv_strBaseAction,
            Name: pv_strName,
            Description: pv_strDescription
        });
    }
    Shop_1.Fill = Fill;
    function start() {
        $('#tbxName').focus();
    }
    Shop_1.start = start;
})(Shop || (Shop = {}));
//# sourceMappingURL=Shop.js.map