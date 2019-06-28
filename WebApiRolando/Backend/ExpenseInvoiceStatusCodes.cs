using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.Models;

namespace WebApiRolando.Backend
{
    public class ExpenseInvoiceStatusCodes
    {
        public const int ExpenseActive = 1;
        public const int ExpensePayed = 2;

        public List<TextValue> GetAllExpenseInvoiceStatusCodes()
        {
            var statusCodes = new List<TextValue>();
            statusCodes.Add(new TextValue("Activo", ExpenseActive));
            statusCodes.Add(new TextValue("Pagado", ExpensePayed));

            return statusCodes;
        }
    }
}