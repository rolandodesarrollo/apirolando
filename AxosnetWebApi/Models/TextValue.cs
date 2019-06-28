using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace AxosnetWebApi.Models
{

    [TsClass]
    public class TextValue
    {
        public string Text { get; set; }
        public long Value { get; set; }
    }
}