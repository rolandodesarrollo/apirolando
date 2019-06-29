using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.Backend;

namespace WebApiRolando.Models.ExpenseInvoices
{
    public class ExpenseInvoiceDTO
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
        public string ProviderName { get; internal set; }
        public string StatusText
        {
            get
            {
                return new ExpenseInvoiceStatusCodes()
                    .GetAllExpenseInvoiceStatusCodes()
                    .FirstOrDefault(f => f.Value == this.Status).Text;
            }
        }
    }
}