using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRolando.Models
{
    public class TextValue
    {
        public TextValue(string Text, int Value)
        {
            this.Text = Text;
            this.Value = Value;
        }
        public string Text { get; set; }
        public int Value { get; set; }
    }
}