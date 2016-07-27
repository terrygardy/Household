/// <reference path="typings/jquery.validation/jquery.validation.d.ts" />
module Validation {
	export function validateForm() {
		validate('form', {
			errorLabelContainer: '#ulError',
			wrapper: 'li'
		});
	}

	export function validate(pv_strSelector: string, pv_arrOptions: JQueryValidation.ValidationOptions) {
		$(pv_strSelector).validate(pv_arrOptions);
	}
}