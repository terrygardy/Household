/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var BankAccount;
(function (BankAccount_1) {
    var m_objBankAccount;
    var BankAccount = (function (_super) {
        __extends(BankAccount, _super);
        function BankAccount(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.AccountName = ko.observable(pv_objOptions.AccountName);
            this.BankName = ko.observable(pv_objOptions.BankName);
            this.IBAN = ko.observable(pv_objOptions.IBAN);
            this.BIC = ko.observable(pv_objOptions.BIC);
            ko.applyBindings(this);
        }
        BankAccount.prototype.Save = function () {
            this.IBAN(this.IBAN().toString().toUpperCase());
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.AccountName(), this.BankName(), this.IBAN()]);
        };
        BankAccount.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, false);
        };
        return BankAccount;
    }(MasterData.BaseMasterData));
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
        this.m_objBankAccount = new BankAccount({
            ID: pv_intID,
            AccountName: pv_strAccountName,
            BankName: pv_strBankName,
            IBAN: formatIBAN(pv_strIBAN),
            BIC: pv_strBIC,
            BaseAction: pv_strBaseAction
        });
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