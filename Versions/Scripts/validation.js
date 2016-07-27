/// <reference path="typings/jquery.validation/jquery.validation.d.ts" />
var Validation;
(function (Validation) {
    function validateForm() {
        validate('form', {
            errorLabelContainer: '#ulError',
            wrapper: 'li'
        });
    }
    Validation.validateForm = validateForm;
    function validate(pv_strSelector, pv_arrOptions) {
        $(pv_strSelector).validate(pv_arrOptions);
    }
    Validation.validate = validate;
})(Validation || (Validation = {}));
//# sourceMappingURL=validation.js.map