using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception.Task2.ConverterExceptions
{
    public class IncorrectFormatException : System.Exception
    {
        public IncorrectFormatException()
            : base()
        {
        }

        public IncorrectFormatException(string message)
            : base(message)
        {
        }

        public IncorrectFormatException(string message, System.Exception innerException)
            : base(message, innerException)

        {
        }
    }
}
