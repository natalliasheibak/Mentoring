using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpHandler
{
    public class MyHttpHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var condition = new Condition();
            condition.CustomerID = context.Request.QueryString["customerid"];
            condition.DateFrom = context.Request.QueryString["datefrom"];
            condition.DateTo = context.Request.QueryString["dateto"];
            condition.Take = Convert.ToInt32(context.Request.QueryString["take"]);
            condition.Skip = Convert.ToInt32(context.Request.QueryString["skip"]);

            var table = DatabaseHelper.GetTable(condition);

            SetResponse(context, table);
        }

        private void SetResponse(HttpContext context, DataTable table)
        {
            List<byte> output = new List<byte>();
            switch (context.Request.Headers["Accept"])
            {
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "text/xml":
                case "application/xml":
                    context.Response.ContentType = "application/xml";
                    output = Encoding.ASCII.GetBytes(XMLWriter.Write(table)).ToList();
                    break;
                default:
                    context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    output = ExcelWriter.WriteToExcel(table).ToList();
                    break;
            }

            context.Response.OutputStream.Write(output.ToArray(), 0, output.Count());
        }
    }
}