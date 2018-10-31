using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class FileFoundEventArgs : WorkEventArgs
    {
        public string FileName { get; }

        public FileFoundEventArgs(string message, string fileName)
            : base(message)
        {
            FileName = fileName;
        }
    }
}
