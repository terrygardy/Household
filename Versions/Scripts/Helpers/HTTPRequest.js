var Helpers;
(function (Helpers) {
    var HttpRequests;
    (function (HttpRequests) {
        function GetMethodGET() { return "GET"; }
        HttpRequests.GetMethodGET = GetMethodGET;
        function GetMethodPOST() { return "POST"; }
        HttpRequests.GetMethodPOST = GetMethodPOST;
        function GetContentTypeJson() { return "application/json"; }
        HttpRequests.GetContentTypeJson = GetContentTypeJson;
        function GetContentTypeText() { return "application/text"; }
        HttpRequests.GetContentTypeText = GetContentTypeText;
        function GetContentTypeForm() { return "application/x-www-form-urlencoded"; }
        HttpRequests.GetContentTypeForm = GetContentTypeForm;
        /*
         Async HTTP-Requests
         */
        function CreateAsyncRequestHandlerGET(pv_strURL, pv_strContentType) {
            return this.CreateAsyncRequestHandler(this.GetMethodGET(), pv_strURL, pv_strContentType);
        }
        HttpRequests.CreateAsyncRequestHandlerGET = CreateAsyncRequestHandlerGET;
        function CreateAsyncRequestHandlerPOST(pv_strURL, pv_strContentType) {
            return this.CreateAsyncRequestHandler(this.GetMethodPOST(), pv_strURL, pv_strContentType);
        }
        HttpRequests.CreateAsyncRequestHandlerPOST = CreateAsyncRequestHandlerPOST;
        function CreateAsyncRequestHandler(pv_strMethod, pv_strURL, pv_strContentType) {
            return this.CreateRequestHandler(pv_strMethod, pv_strURL, true, pv_strContentType);
        }
        HttpRequests.CreateAsyncRequestHandler = CreateAsyncRequestHandler;
        /*
         Sync HTTP-Requests
         */
        function CreateSyncRequestHandlerGET(pv_strURL, pv_strContentType) {
            return this.CreateSyncRequestHandler(this.GetMethodGET(), pv_strURL, pv_strContentType);
        }
        HttpRequests.CreateSyncRequestHandlerGET = CreateSyncRequestHandlerGET;
        function CreateSyncRequestHandlerPOST(pv_strURL, pv_strContentType) {
            return this.CreateSyncRequestHandler(this.GetMethodPOST(), pv_strURL, pv_strContentType);
        }
        HttpRequests.CreateSyncRequestHandlerPOST = CreateSyncRequestHandlerPOST;
        function CreateSyncRequestHandler(pv_strMethod, pv_strURL, pv_strContentType) {
            return this.CreateRequestHandler(pv_strMethod, pv_strURL, false, pv_strContentType);
        }
        HttpRequests.CreateSyncRequestHandler = CreateSyncRequestHandler;
        /*
            Base function
         */
        function CreateRequestHandler(pv_strMethod, pv_strURL, pv_blnAsync, pv_strContentType) {
            var objRequestHandler = new XMLHttpRequest();
            objRequestHandler.open(pv_strMethod, pv_strURL, pv_blnAsync);
            if ((pv_strContentType === undefined) || (pv_strContentType === null) || (pv_strContentType === '')) {
                pv_strContentType = this.GetContentTypeForm();
            }
            objRequestHandler.setRequestHeader("Content-Type", pv_strContentType);
            objRequestHandler.setRequestHeader("Access-Control-Allow-Origin", "*");
            return objRequestHandler;
        }
        HttpRequests.CreateRequestHandler = CreateRequestHandler;
    })(HttpRequests = Helpers.HttpRequests || (Helpers.HttpRequests = {}));
})(Helpers || (Helpers = {}));
//# sourceMappingURL=httprequest.js.map