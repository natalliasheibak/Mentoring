using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace HttpHandler
{
    public class ExcelWriter
    {
        public static byte[] WriteToExcel(DataTable table)
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(table);

                using (var ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);

                    return ms.ToArray();
                }
            }
        }
    }
}