using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL.Exceptions
{
    public class OrderIsNotDeletedException : Exception
    {
        public OrderIsNotDeletedException()
        {
        }

        public OrderIsNotDeletedException(string message)
        : base(message)
        {
        }

        public OrderIsNotDeletedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
