using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuget
{
    public class Class1
    {
        public void Write(string sentence)
        {
            var jObject = new JObject();
            Console.WriteLine(sentence);
        }
    }
}
