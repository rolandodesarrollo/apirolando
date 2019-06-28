
 
 

 

/// <reference path="Enums.ts" />

declare module AxosnetWebApi.Models {
	interface ProviderVM {
		Id: number;
		ProviderName: string;
		Telephone: string;
	}
	interface TextValue {
		Text: string;
		Value: number;
	}
}
declare module AxosnetWebApi.Models.ExpenseInvoices {
	interface ExpenseBackendDataVM {
		Currencies: string[];
		Providers: AxosnetWebApi.Models.TextValue[];
	}
}


