using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models.ExpenseInvoices
{
    [TsClass]
    public class ExpenseBackendDataVM
    {
        public List<TextValue> Providers { get; set; }
        public List<string>  Currencies { get; set; }

    }
}