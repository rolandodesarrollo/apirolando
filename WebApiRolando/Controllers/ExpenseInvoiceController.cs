using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiRolando.Backend;
using WebApiRolando.Models.ExpenseInvoices;
using WebApiRolando.Models.Providers;

namespace WebApiRolando.Controllers
{
    public class ExpenseInvoiceController : ApiController
    {
        // GET: ExpenseInvoice

        public List<ExpenseInvoiceDTO> GetAllExpenseInvoices()
        {
            var expenses = new ExpenseInvoiceSC().GetAllExpensesList();
            return expenses;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/AddNewExpenseInvoice")]
        public long AddExpense(string concept, long providerId, decimal exchangeRate, decimal total, string currencyCode, string additionalNotes)
        {
            return new ExpenseInvoiceSC().AddExpenseInvoice(concept, providerId, exchangeRate, total, currencyCode, additionalNotes);
        }
    }
}