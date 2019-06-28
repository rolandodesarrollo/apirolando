using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.DataAccess;
using WebApiRolando.Models.ExpenseInvoices;

namespace WebApiRolando.Backend
{
    public class ExpenseInvoiceSC : BaseSC
    {

        public long AddExpenseInvoice(string concept, long providerId, decimal exchangeRate, decimal total, string currencyCode, string additionalNotes)
        {
            var newExpenseInvoice = new ExpenseInvoices();
            newExpenseInvoice.Concept = concept;
            newExpenseInvoice.ProviderId = providerId;
            newExpenseInvoice.ExchangeRate = exchangeRate;
            newExpenseInvoice.CurrencyCode = currencyCode;
            newExpenseInvoice.AdditionalNotes = additionalNotes;
            newExpenseInvoice.Status = 1;// Active
            newExpenseInvoice.Total = total;
            newExpenseInvoice.Pending = total;
            
            DataContext.ExpenseInvoices.Add(newExpenseInvoice);
            DataContext.SaveChanges();
            DataContext.Entry(newExpenseInvoice).GetDatabaseValues();
            return newExpenseInvoice.Id;
            

        }

        public List<ExpenseInvoiceDTO> GetAllExpensesList()
        {
            var expenses = DataContext.ExpenseInvoices.Select(s => new ExpenseInvoiceDTO() {
                Id = s.Id, 
                Pending = s.Pending,
                Concept = s.Concept, 
                AdditionalNotes = s.AdditionalNotes,
                ProviderId = s.ProviderId,
                ProviderName = s.ProviderId + " - " + s.Providers.ProviderName,
                CurrencyCode = s.CurrencyCode,
                ExchangeRate = s.ExchangeRate,
                Status = s.Status,
                Total = s.Total,
                
            }).ToList();

            return expenses;
        }
    }
}