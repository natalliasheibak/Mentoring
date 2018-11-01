using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Filter
    {
        public List<string> StringList { get; private set; }

        public Filter(List<string> listOfStrings)
        {
            StringList = listOfStrings;

        }

        public string GetFirstLettersOfStrings()
        {
            var result = null as string;

            foreach(var item in StringList)
            {
                try
                {
                    result += item.ElementAt(0);
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
            }

            return result;
        }
    }
}
