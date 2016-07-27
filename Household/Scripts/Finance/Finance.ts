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
}