/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var Person;
(function (Person_1) {
    var m_objPerson;
    var Person = (function () {
        function Person(pv_intID, pv_strSurname, pv_strForename, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.Surname = ko.observable(pv_strSurname);
            this.Forename = ko.observable(pv_strForename);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Person.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Person: this }), [this.Surname(), this.Forename()]);
        };
        Person.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Person;
    }());
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
        this.m_objPerson = new Person(pv_intID, pv_strSurname, pv_strForename, pv_strBaseAction);
    }
    Person_1.Fill = Fill;
    function start() {
        $('#tbxSurname').focus();
    }
    Person_1.start = start;
})(Person || (Person = {}));
//# sourceMappingURL=Person.js.map