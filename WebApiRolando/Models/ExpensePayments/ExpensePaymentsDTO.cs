using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRolando.Models.ExpensePayments
{
    public class ExpensePaymentsDTO
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string ProviderName { get; set; }
        public string CreationDate { get; set; }
        public string CurrencyCode { get; set; }
        public string ExpenseText { get; set; }
        public string Comment { get; set; }
    }
}