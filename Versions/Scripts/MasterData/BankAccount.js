/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var BankAccount;
(function (BankAccount_1) {
    var m_objBankAccount;
    var BankAccount = (function () {
        function BankAccount(pv_intID, pv_strAccountName, pv_strBankName, pv_strIBAN, pv_strBIC, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.AccountName = ko.observable(pv_strAccountName);
            this.BankName = ko.observable(pv_strBankName);
            this.IBAN = ko.observable(pv_strIBAN);
            this.BIC = ko.observable(pv_strBIC);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        BankAccount.prototype.Save = function () {
            this.IBAN(this.IBAN().toString().toUpperCase());
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ BankAccount: this }), [this.AccountName(), this.BankName(), this.IBAN()]);
        };
        BankAccount.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return BankAccount;
    }());
    BankAccount_1.BankAccount = BankAccount;
    function Save() {
        this.m_objBankAccount.Save();
    }
    BankAccount_1.Save = Save;
    function Delete() {
        this.m_objBankAccount.Delete();
    }
    BankAccount_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strAccountName, pv_strBankName, pv_strIBAN, pv_strBIC) {
        this.m_objBankAccount = new BankAccount(pv_intID, pv_strAccountName, pv_strBankName, formatIBAN(pv_strIBAN), pv_strBIC, pv_strBaseAction);
    }
    BankAccount_1.Fill = Fill;
    function formatIBAN(pv_strIBAN) {
        var i = 4;
        pv_strIBAN = pv_strIBAN.replace(/-/g, '').replace(/ /g, '').toUpperCase();
        while (i < pv_strIBAN.length) {
            pv_strIBAN = Common.AddCharacterToText(pv_strIBAN, i, '-');
            i += 5;
        }
        return pv_strIBAN.substr(0, (pv_strIBAN.length < 27 ? pv_strIBAN.length : 27));
    }
    BankAccount_1.formatIBAN = formatIBAN;
    function start() {
        $('#tbxIBAN').keyup(keyUpIBAN);
        $('#tbxAccountName').focus();
    }
    BankAccount_1.start = start;
    function keyUpIBAN(e) {
        if ((e.which > 47) && (e.which < 90)) {
            var objTextBox = this;
            var strValue = objTextBox.value;
            strValue = formatIBAN(strValue);
            objTextBox.value = strValue;
        }
    }
})(BankAccount || (BankAccount = {}));
//# sourceMappingURL=BankAccount.js.map