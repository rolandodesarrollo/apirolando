using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxosnetWebApi.Models
{
    public class Currencies
    {
        public static List<string> GetCurrencyCodes()
        {
            var codes = new List<string>();
            codes.Add("MXN");
            codes.Add("USD");
            codes.Add("COP");
            codes.Add("BRL");
            return codes;
        }
    }
}