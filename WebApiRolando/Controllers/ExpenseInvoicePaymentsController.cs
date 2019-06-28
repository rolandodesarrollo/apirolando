using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiRolando.Backend;

namespace WebApiRolando.Controllers
{
    public class ExpenseInvoicePaymentsController : ApiController
    {
        // GET: ExpenseInvoicePayments
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/AddExpensePayment")]
        public long AddExpensePayment(decimal amount, long expenseID, string comment, DateTime creationDate, decimal exchangeRate, string currencyCode)
        {
            return new ExpenseInvoicePaymentSC().AddExpenseInvoicePayment(amount, expenseID, comment, creationDate, exchangeRate, currencyCode);
        }
    }
}