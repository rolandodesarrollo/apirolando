using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.Backend;
using WebApiRolando.DataAccess;
using WebApiRolando.Models.ExpensePayments;

namespace WebApiRolando.Backend
{
    public class ExpenseInvoicePaymentSC : BaseSC
    {
        public long AddExpenseInvoicePayment(decimal amount, long expenseID, string comment, string creationDate, decimal exchangeRate, string currencyCode)
        {
            var expense = DataContext.ExpenseInvoices.FirstOrDefault(f => f.Id == expenseID);

            if (expense == null)
                return -1;

            if (expense.Pending <= 0)
                return -2;

            if ((amount * exchangeRate) > expense.Pending)
                return -3;

            if (expense.Status == ExpenseInvoiceStatusCodes.ExpensePayed)
                return -4;

            var expensePayment = new ExpensePayments()
            {
                Amount = amount * exchangeRate,
                Comment = comment,
                CreationDate = DateTime.Parse(creationDate),
                CurrencyCode = currencyCode,
                ExpenseInvoiceID = expenseID,
                ExchangeRate = exchangeRate,
            };

            DataContext.ExpensePayments.Add(expensePayment);
            DataContext.SaveChanges();
            new ExpenseInvoiceSC().UpdateExpenseByPayment(expenseID, amount*exchangeRate);

            DataContext.Entry(expensePayment).GetDatabaseValues();
            return expensePayment.Id;

        }

        public List<ExpensePaymentsDTO> GetAllExpensePaymentsList()
        {
            var payments = DataContext.ExpensePayments.Select(s => new ExpensePaymentsDTO()
            {
                Id = s.Id,
                Amount = s.Amount,
                CreationDate = s.CreationDate.ToString(),
                ProviderName = s.ExpenseInvoices.Providers.ProviderName,
                CurrencyCode = s.CurrencyCode,
                ExpenseText = "Gasto # " + s.ExpenseInvoiceID + " -" + s.ExpenseInvoices.Providers.ProviderName,
                Comment = s.Comment,
            }).ToList();

            return payments;
        }
    }
}