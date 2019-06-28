using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.Backend;
using WebApiRolando.DataAccess;

namespace WebApiRolando.Backend
{
    public class ExpenseInvoicePaymentSC : BaseSC
    {
        public long AddExpenseInvoicePayment(decimal amount, long expenseID, string comment, DateTime creationDate, decimal exchangeRate, string currencyCode)
        {
            var expensePayment = new ExpensePayments()
            {
                Amount = amount,
                Comment = comment,
                CreationDate = creationDate,
                CurrencyCode = currencyCode,
                ExpenseInvoiceID = expenseID,
                ExchangeRate = exchangeRate,
            };

            DataContext.ExpensePayments.Add(expensePayment);
            DataContext.SaveChanges();
            new ExpenseInvoiceSC().UpdateExpenseByPayment(expenseID, amount);

            DataContext.Entry(expensePayment).GetDatabaseValues();
            return expensePayment.Id;

        }
    }
}