using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'end' once you're done typing");

            var stringFilter = new Filter(ReadStringsFromConsole());

            Console.WriteLine(stringFilter.GetFirstLettersOfStrings());
            Console.ReadKey();
        }

        public static List<string> ReadStringsFromConsole()
        {
            var lines = new List<string>();
            var currentLine = string.Empty;
            while ((currentLine = Console.ReadLine()) != "end")
            {
                lines.Add(currentLine);
            }

            return lines;
        }
    }
}
