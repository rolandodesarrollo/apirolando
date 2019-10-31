﻿using AxosnetWebApi.Models;
using AxosnetWebApi.Models.ExpenseInvoicePayments;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.Backend;

namespace AxosnetWebApi.ServiceComponents
{
    public class ExpenseInvoicePaymentsSC : BaseSC
    {
        public object ExpenseInvoicesStatusCodes { get; private set; }

        public ExpensePaymentsBackendDataVM GetExpensePaymentsViewBagData()
        {
            var backendData = new ExpensePaymentsBackendDataVM();
            backendData.Expenses =  new ExpenseInvoicesSC().GetAllExpenseInvoices().Where(w=> w.Status == ExpenseInvoiceStatusCodes.ExpenseActive)
                   .Select(s => new TextValue { Text = "Gasto #" + s.Id + "- Proveedor" + s.ProviderName + " $" + s.Pending + " " + s.CurrencyCode
                   , Value = s.Id }).ToList();
            backendData.Currencies = Currencies.GetCurrencyCodes();

            return backendData;
        }

        public List<ExpensePaymentsVM> GetAllExpensePayments()
        {
            var paymentListJson =  GetApiResponse("http://apirolando.azurewebsites.net/api/ExpenseInvoicePayments");
            var payments = DeserializeJson(new List<ExpensePaymentsVM>(), paymentListJson.Content);
            return payments;

        }

        public long AddExpensePayment(decimal amount, long expenseID, string comment, DateTime creationDate, decimal exchangeRate, string currencyCode)
        {
            var url = "http://apirolando.azurewebsites.net/api/AddExpensePayment?amount=" + amount + "&expenseID=" + expenseID
                + "&comment=" + comment + "&creationDate=" + creationDate.ToString() + "&exchangeRate=" + exchangeRate + "&currencyCode=" + currencyCode;
            IRestResponse response = PostAPIResponse(url);
            try
            {
                return long.Parse(response.Content);
            }
            catch (Exception)
            {
            }
            return 0;
        }
    }
}