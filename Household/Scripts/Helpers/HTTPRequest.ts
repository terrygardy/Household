module Helpers.HttpRequests {
	export function GetMethodGET(): string { return "GET"; }
	export function GetMethodPOST(): string { return "POST"; }

	export function GetContentTypeJson(): string { return "application/json"; }
	export function GetContentTypeText(): string { return "application/text"; }
	export function GetContentTypeForm(): string { return "application/x-www-form-urlencoded"; }

	/*
	 Async HTTP-Requests
	 */
	export function CreateAsyncRequestHandlerGET(pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateAsyncRequestHandler(this.GetMethodGET(), pv_strURL, pv_strContentType);
	}

	export function CreateAsyncRequestHandlerPOST(pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateAsyncRequestHandler(this.GetMethodPOST(), pv_strURL, pv_strContentType);
	}

	export function CreateAsyncRequestHandler(pv_strMethod: string, pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateRequestHandler(pv_strMethod, pv_strURL, true, pv_strContentType);
	}

	/*
	 Sync HTTP-Requests
	 */
	export function CreateSyncRequestHandlerGET(pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateSyncRequestHandler(this.GetMethodGET(), pv_strURL, pv_strContentType);
	}

	export function CreateSyncRequestHandlerPOST(pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateSyncRequestHandler(this.GetMethodPOST(), pv_strURL, pv_strContentType);
	}

	export function CreateSyncRequestHandler(pv_strMethod: string, pv_strURL: string, pv_strContentType: string): XMLHttpRequest {
		return this.CreateRequestHandler(pv_strMethod, pv_strURL, false, pv_strContentType);
	}

	/*
		Base function
	 */
	export function CreateRequestHandler(pv_strMethod: string, pv_strURL: string, pv_blnAsync: boolean, pv_strContentType: string): XMLHttpRequest {
		var objRequestHandler: XMLHttpRequest = new XMLHttpRequest();

		objRequestHandler.open(pv_strMethod, pv_strURL, pv_blnAsync);

		if ((pv_strContentType === undefined) || (pv_strContentType === null) || (pv_strContentType === '')) { pv_strContentType = this.GetContentTypeForm(); }

		objRequestHandler.setRequestHeader("Content-Type", pv_strContentType);
		objRequestHandler.setRequestHeader("Access-Control-Allow-Origin", "*");

		return objRequestHandler;
	}
}