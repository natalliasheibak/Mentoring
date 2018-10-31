using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DirectoryFoundEventArgs : WorkEventArgs
    {
        public string FileName { get; }

        public DirectoryFoundEventArgs(string message, string fileName)
            : base(message)
        {
            FileName = fileName;
        }
    }
}
