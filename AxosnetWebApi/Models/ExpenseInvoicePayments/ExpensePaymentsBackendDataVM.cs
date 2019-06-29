using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models.ExpenseInvoicePayments
{

    [TsClass]
    public class ExpensePaymentsBackendDataVM
    {
        public List<TextValue> Expenses { get; set; }
        public List<string> Currencies { get; set; }

    }

    
}