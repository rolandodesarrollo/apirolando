using AxosnetWebApi.ServiceComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AxosnetWebApi.Controllers
{
    public class ExpenseInvoicePaymentController : BaseController
    {
        // GET: ExpenseInvoicePayment
        public ActionResult ExpensePaymentsList()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            var backendData = new ExpenseInvoicePaymentsSC().GetExpensePaymentsViewBagData();
            ViewBag.backendData = SerializeJSONData(backendData);
            return View();
        }

        public ActionResult GetAllExpensePayments()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            var expenses = new ExpenseInvoicePaymentsSC().GetAllExpensePayments();
            return GetJsonNetResult(expenses);
        }

        [HttpPost]
        public ActionResult AddExpensePayment(decimal amount, long expenseID, string comment, DateTime creationDate, decimal exchangeRate, string currencyCode)
        {
            return GetJsonNetResult(new ExpenseInvoicePaymentsSC().AddExpensePayment(amount, expenseID, comment, creationDate, exchangeRate, currencyCode));
        }
    }

}