using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models.ExpenseInvoices
{
    [TsClass]
    public class ExpenseInvoiceVM
    {
        public long Id { get; set; }
        public string Concept { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Total { get; set; }
        public decimal Pending { get; set; }
        public string AdditionalNotes { get; set; }
        public long ProviderId { get; set; }
        public int Status { get; set; }
        public string ProviderName { get; set; }
    }
}