using AxosnetWebApi.Models;
using AxosnetWebApi.Models.ExpenseInvoicePayments;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxosnetWebApi.ServiceComponents
{
    public class ExpenseInvoicePaymentsSC : BaseSC
    {

        public ExpensePaymentsBackendDataVM GetExpensePaymentsViewBagData()
        {
            var backendData = new ExpensePaymentsBackendDataVM();
            backendData.Expenses =  new ExpenseInvoicesSC().GetAllExpenseInvoices()
                   .Select(s => new TextValue { Text = "Gasto #" + s.Id
                   , Value = s.Id }).ToList();
            backendData.Currencies = Currencies.GetCurrencyCodes();

            return backendData;
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