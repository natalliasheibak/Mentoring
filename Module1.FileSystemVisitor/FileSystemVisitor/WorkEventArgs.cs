using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WorkEventArgs : EventArgs
    {
        public string Message { get; }

        public WorkEventArgs(string message)
        {
            Message = message;
        }
    }
}
