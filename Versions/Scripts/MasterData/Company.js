/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var Company;
(function (Company_1) {
    var m_objCompany;
    var Company = (function () {
        function Company(pv_intID, pv_strName, pv_strDescription, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.Name = ko.observable(pv_strName);
            this.Description = ko.observable(pv_strDescription);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Company.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Company: this }), [this.Name(), this.Description()]);
        };
        Company.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Company;
    }());
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
        this.m_objCompany = new Company(pv_intID, pv_strName, pv_strDescription, pv_strBaseAction);
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