using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models
{
    [TsClass]
    public class ProviderVM
    {
        public long Id { get; set; }
        public string ProviderName { get; set; }
        public string Telephone { get; set; }
    }
}