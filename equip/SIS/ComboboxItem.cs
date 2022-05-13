using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIS
{
    class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public ComboboxItem(string txt,string val)
        {
            Text = txt;
            Value = val;
        }
    }
}
