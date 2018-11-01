using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception.Task2.ConverterExceptions
{
    public class NullException : System.Exception
    {
        public NullException()
            : base()
        {
        }

        public NullException(string message)
            : base(message)
        {
        }

        public NullException(string message, System.Exception innerException)
            : base(message, innerException)

        {
        }
    }
}
