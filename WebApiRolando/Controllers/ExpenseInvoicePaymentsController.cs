﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiRolando.Backend;
using WebApiRolando.Models.Providers;

namespace WebApiRolando.Controllers
{
    public class ExpenseInvoicePaymentsController : ApiController
    {

        public List<ProvidersDTO> GetAllProviders()
        {
            var providers = new ProviderSC().GetAllProvidersList();
            return providers;
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/AddExpensePayment")]
        public long AddPayment(decimal amount, long expenseID, string comment, string creationDate, decimal exchangeRate, string currencyCode)
        {
            return new ExpenseInvoicePaymentSC().AddExpenseInvoicePayment(amount, expenseID, comment, creationDate, exchangeRate, currencyCode);
        }
    }
}