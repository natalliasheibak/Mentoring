using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception.Task2
{
    public static class ConvertHelper
    {
        public static int ConvertToInt(string stringValue)
        {
            var converter = new Converter(stringValue);
            return converter.ToInt();
        }
    }
}
