/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../Helpers/HTTPRequest.ts" />
/// <reference path="../jquery-pleaseWait.ts" />

module Finance {
	class Shop {
		ID: number;
		Name: string;
	}

	class Purchase {
		ID: number;
		Price: number;
		Amount: number;
		Shop: Shop;
	}

	export function updateBankBalance() {
		let jqBreadCrumb = $(".breadcrumb");

		if (jqBreadCrumb.length > 0) {
			try {
				jqBreadCrumb = $(jqBreadCrumb[0]);
				let jqBankBalance = jqBreadCrumb.children("li.bankBalance");

				if (jqBankBalance.length < 1) {
					jqBreadCrumb.append("<li class=\"bankBalance fRight\"></li>");

					jqBankBalance = jqBreadCrumb.children("li.bankBalance")
				}

				let request = Helpers.HttpRequests.CreateAsyncRequestHandlerPOST("/Banking/GetCurrentBankBalance", Helpers.HttpRequests.GetContentTypeForm());

				request.onload = (e) => {
					jqBankBalance.html(request.responseText);
				}

				request.send(null);
			}
			catch (ex) {
				alert(ex);
			}
		}
	}
}

$(Finance.updateBankBalance);