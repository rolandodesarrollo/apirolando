using AxosnetWebApi.Models;
using AxosnetWebApi.Models.ExpenseInvoicePayments;
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
    }
}