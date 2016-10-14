/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Person;
(function (Person_1) {
    var m_objPerson;
    var Person = (function (_super) {
        __extends(Person, _super);
        function Person(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.Surname = ko.observable(pv_objOptions.Surname);
            this.Forename = ko.observable(pv_objOptions.Forename);
            ko.applyBindings(this);
        }
        Person.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Surname(), this.Forename()]);
        };
        Person.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, false);
        };
        return Person;
    }(MasterData.BaseMasterData));
    Person_1.Person = Person;
    function Save() {
        this.m_objPerson.Save();
    }
    Person_1.Save = Save;
    function Delete() {
        this.m_objPerson.Delete();
    }
    Person_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strSurname, pv_strForename) {
        this.m_objPerson = new Person({ ID: pv_intID, Surname: pv_strSurname, Forename: pv_strForename, BaseAction: pv_strBaseAction });
    }
    Person_1.Fill = Fill;
    function start() {
        $('#tbxSurname').focus();
    }
    Person_1.start = start;
})(Person || (Person = {}));
//# sourceMappingURL=Person.js.map