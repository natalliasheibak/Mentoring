using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception.Task2.ConverterExceptions
{
    public class EmptyStringException : System.Exception
    {
        public EmptyStringException()
            : base()
        {
        }

        public EmptyStringException(string message)
            : base(message)
        {
        }

        public EmptyStringException(string message, System.Exception innerException)
            : base(message, innerException)

        {
        }
    }
}
