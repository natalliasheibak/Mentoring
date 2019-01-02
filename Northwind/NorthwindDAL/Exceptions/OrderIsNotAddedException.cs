using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL.Exceptions
{
    public class OrderIsNotAddedException : Exception
    {
        public OrderIsNotAddedException()
        {
        }

        public OrderIsNotAddedException(string message)
        : base(message)
        {
        }

        public OrderIsNotAddedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
