﻿using AxosnetWebApi.Models;
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
            var backendData = new ProvidersSC().GetAllProviders()
                .Select(s =>  new TextValue { Text = s.ProviderName, Value = s.Id }).ToList();

            ViewBag.backendData = SerializeJSONData(backendData);
            return View();
        }

        [HttpPost]
        public ActionResult AddNewExpenseInvoice(string concept, long providerID, decimal amount, string currencyCode)
        {
            var result = new ExpenseInvoicesSC().AddNewExpenseInvoice(concept, providerID, amount, currencyCode);
            return GetJsonNetResult(result);
        }
    }
}