using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_BCL.Configuration;

namespace Task4_BCL
{
    class Program
    {
        public static bool _cancelled = false;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            ConfigurationHelper.Directories.OfType<DirectoryElement>().Select(x => new Watcher(x.Directory)).ToList().ForEach(x => x.StartWatch());

            while (!_cancelled);
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Cancelling");
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                _cancelled = true;
                e.Cancel = true;
            }
        }
    }
}
