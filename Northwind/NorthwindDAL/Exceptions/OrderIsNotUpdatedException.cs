using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL.Exceptions
{
    public class OrderIsNotUpdatedException : Exception
    {
        public OrderIsNotUpdatedException()
        {
        }

        public OrderIsNotUpdatedException(string message)
        : base(message)
        {
        }

        public OrderIsNotUpdatedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
