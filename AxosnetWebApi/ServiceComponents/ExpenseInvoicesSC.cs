using AxosnetWebApi.Models;
using AxosnetWebApi.Models.ExpenseInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxosnetWebApi.ServiceComponents
{
    public class ExpenseInvoicesSC: BaseSC
    {

        public long AddNewExpenseInvoice(string concept, long providerID, decimal amount, string currencyCode)
        {
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