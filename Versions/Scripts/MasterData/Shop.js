/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var Shop;
(function (Shop_1) {
    var m_objShop;
    var Shop = (function () {
        function Shop(pv_intID, pv_strName, pv_strDescription, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.Name = ko.observable(pv_strName);
            this.Description = ko.observable(pv_strDescription);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Shop.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ "Shop": this }), [this.Name(), this.Description()]);
        };
        Shop.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Shop;
    }());
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
        this.m_objShop = new Shop(pv_intID, pv_strName, pv_strDescription, pv_strBaseAction);
    }
    Shop_1.Fill = Fill;
    function start() {
        $('#tbxName').focus();
    }
    Shop_1.start = start;
})(Shop || (Shop = {}));
//# sourceMappingURL=Shop.js.map