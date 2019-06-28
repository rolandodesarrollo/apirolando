using AxosnetWebApi.Models;
using AxosnetWebApi.ServiceComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AxosnetWebApi.Controllers
{
    public class ExpenseInvoicesController : BaseController
    {
        // GET: ExpenseInvoices
        public ActionResult ExpenseList()
        {
            var backendData = new ExpenseInvoicesSC().GetExpenseListBackendData();
            ViewBag.backendData = SerializeJSONData(backendData);
            
            return View();
        }

        public ActionResult GetAllExpenseInvoices()
        {
            var providers = new ExpenseInvoicesSC().GetAllExpenseInvoices();
            return GetJsonNetResult(providers);
        }

        [HttpPost]
        public ActionResult AddNewExpenseInvoice(string concept, long providerID, decimal amount, string currencyCode, decimal exchangeRate)
        {
            var result = new ExpenseInvoicesSC().AddNewExpenseInvoice(concept, providerID, amount, currencyCode, exchangeRate);
            return GetJsonNetResult(result);
        }
    }
}