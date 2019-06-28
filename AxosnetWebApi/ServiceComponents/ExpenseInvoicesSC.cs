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
            //var url = "http://apirolando.azurewebsites.net/api/AddNewProvider?ProviderName=" + ProviderName + "&Telephone=" + Telephone;
            //IRestResponse response = PostAPIResponse(url);
            //try
            //{
            //    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            //    var r = jsSerializer.Deserialize<RequestMessage>(response.Content);

            //    if (r.code != "200")
            //    {
            //        return r.message;
            //    }
            //}
            //catch (Exception)
            //{

            //}

            return 0;
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