/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Company;
(function (Company_1) {
    var m_objCompany;
    var Company = (function (_super) {
        __extends(Company, _super);
        function Company(pv_objOptions) {
            var _this = _super.call(this, pv_objOptions) || this;
            ko.applyBindings(_this);
            return _this;
        }
        Company.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Name(), this.Description()]);
        };
        Company.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, false);
        };
        return Company;
    }(MasterData.BaseNameDescMasterData));
    Company_1.Company = Company;
    function Save() {
        this.m_objCompany.Save();
    }
    Company_1.Save = Save;
    function Delete() {
        this.m_objCompany.Delete();
    }
    Company_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strName, pv_strDescription) {
        this.m_objCompany = new Company({
            ID: pv_intID,
            Name: pv_strName,
            Description: pv_strDescription,
            BaseAction: pv_strBaseAction
        });
    }
    Company_1.Fill = Fill;
    function start() {
        $('#tbxName').focus();
    }
    Company_1.start = start;
    function GetNameByID(pv_intID) {
        var strName = '';
        try {
            var objRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST('/Company/GetNameByID/' + pv_intID.toString(), Helpers.HttpRequests.GetContentTypeForm());
            objRequest.send();
            strName = objRequest.response;
        }
        catch (ex) {
            strName = 'unknown';
        }
        return strName;
    }
    Company_1.GetNameByID = GetNameByID;
})(Company || (Company = {}));
//# sourceMappingURL=Company.js.map