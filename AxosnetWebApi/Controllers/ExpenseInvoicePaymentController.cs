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
            var backendData = new ExpenseInvoicePaymentsSC().GetExpensePaymentsViewBagData();
            ViewBag.backendData = SerializeJSONData(backendData);
            return View();
        }
    }
}