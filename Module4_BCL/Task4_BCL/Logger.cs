using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages = Task4_BCL.Resources.Messages;

namespace Task4_BCL
{
    public class Logger
    {
        public Logger()
        {
            Thread.CurrentThread.CurrentCulture = ConfigurationHelper.CultureInfo;
        }

        public void NewFileAddedToFolder(object source, FileSystemEventArgs e)
        {
            Console.WriteLine(string.Format(Messages.NewFileFound, e.Name, Path.GetDirectoryName(e.FullPath)));
        }

        public void PatternFoundForFile(string fileName, string ruleName)
        {
            Console.WriteLine(string.Format(Messages.FileMatchesPattern, fileName, ruleName));
        }

        public void FileMoved(string fileName, string folder)
        {
            Console.WriteLine(string.Format(Messages.FileMoved, fileName, folder));
        }

        public void FileMoveError(string fileName, string folder, Exception ex)
        {
            Console.WriteLine(string.Format(Messages.FileMoveError, fileName, folder));
            Console.WriteLine(ex.Message);
        }
    }
}
