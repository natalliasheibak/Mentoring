using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace HttpHandler
{
    public static class XMLWriter
    {
        public static string Write(DataTable table)
        {
            string result;
            using (StringWriter sw = new StringWriter())
            {
                table.WriteXml(sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}