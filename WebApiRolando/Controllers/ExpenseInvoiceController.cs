using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiRolando.Backend;

namespace WebApiRolando.Controllers
{
    public class ExpenseInvoiceController 
    {
        // GET: ExpenseInvoice
       

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/AddNewExpenseInvoice")]
        public long AddExpense(string concept, long providerId, decimal exchangeRate, decimal total, string currencyCode, string additionalNotes)
        {
            return new ExpenseInvoiceSC().AddExpenseInvoice(concept, providerId, exchangeRate, total, currencyCode, additionalNotes);
        }
    }
}