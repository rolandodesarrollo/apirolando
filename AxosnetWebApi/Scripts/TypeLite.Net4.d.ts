
 
 

 

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
declare module AxosnetWebApi.Models.ExpenseInvoicePayments {
	interface ExpensePaymentsBackendDataVM {
		Currencies: string[];
		Expenses: AxosnetWebApi.Models.TextValue[];
	}
}
declare module AxosnetWebApi.Models.ExpenseInvoices {
	interface ExpenseBackendDataVM {
		Currencies: string[];
		Providers: AxosnetWebApi.Models.TextValue[];
	}
	interface ExpenseInvoiceVM {
		AdditionalNotes: string;
		Concept: string;
		CurrencyCode: string;
		ExchangeRate: number;
		Id: number;
		Pending: number;
		ProviderId: number;
		ProviderName: string;
		Status: number;
		Total: number;
	}
}


