using AxosnetWebApi.Models;
using AxosnetWebApi.Models.ExpenseInvoices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AxosnetWebApi.ServiceComponents
{
    public class ExpenseInvoicesSC: BaseSC
    {

        public long AddNewExpenseInvoice(string concept, long providerID, decimal amount, string currencyCode, decimal exchangeRate)
        {
            var url = "http://apirolando.azurewebsites.net/api/AddNewExpenseInvoice?concept=" + concept + "&providerId=" + providerID
                + "&exchangeRate=" + exchangeRate +"&total=" + amount + "&currencyCode=" + currencyCode + "&additionalNotes=";
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

        public List<ExpenseInvoiceVM> GetAllExpenseInvoices()
        {
            var expensesJson = GetApiResponse("http://apirolando.azurewebsites.net/api/ExpenseInvoice");
            var expenses = DeserializeJson(new List<ExpenseInvoiceVM>(), expensesJson.Content);
            return expenses;
        }

        public ExpenseBackendDataVM GetExpenseListBackendData()
        {
            var backendData = new ExpenseBackendDataVM();
            backendData.Providers = new ProvidersSC().GetAllProviders()
                .Select(s => new TextValue { Text = s.ProviderName, Value = s.Id }).ToList();
            backendData.Currencies = Currencies.GetCurrencyCodes();
            return backendData;
        }
    }
}