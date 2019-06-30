using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models.ExpenseInvoicePayments
{

    [TsClass]
    public class ExpensePaymentsVM
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public string ProviderName { get; set; }
        public string CreationDate { get; set; }
        public string CurrencyCode { get; set; }
        public string ExpenseText { get; set; }
    }
}