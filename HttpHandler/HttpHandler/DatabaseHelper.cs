using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HttpHandler
{
    public class DatabaseHelper
    {
        public static string ConnectionString => @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Condition _condition;

        public static DataTable GetTable(Condition condition)
        {
            DataSet dataSet = new DataSet("Orders");
            _condition = condition;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(GetQuery(), connection);
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "Order");

                return dataSet.Tables["Order"];
            }
        }

        #region private

        private static string GetQuery()
        {
            string topRows = string.Empty;
            if (_condition.Skip == 0 && _condition.Take != 0)
            {
                topRows = $"TOP {_condition.Take}";
            }

            var query = $"SELECT {topRows} * FROM northwind.orders ";
            if (GetConditions().Count > 0)
            {
                query += $"WHERE {GetConditions().First()} ";
                foreach (var condition in GetConditions().Skip(1))
                {
                    query += $"AND {condition} ";
                }
            }

            query += "ORDER BY OrderID ";
            query += GetOffset();

            return query;
        }

        private static List<string> GetConditions()
        {
            var conditions = new List<string>();

            if (_condition.CustomerID != null)
                conditions.Add($"CustomerID = '{_condition.CustomerID}'");

            if (_condition.DateFrom != null)
                conditions.Add($"OrderDate > '{_condition.DateFrom}'");

            if (_condition.DateTo != null)
                conditions.Add($"OrderDate < '{_condition.DateTo}'");

            return conditions;
        }

        private static string GetOffset()
        {
            string offset = string.Empty;
            if (_condition.Skip != 0 && _condition.Take != 0)
            {
                offset = $"OFFSET {_condition.Skip} ROWS FETCH NEXT {_condition.Take} ROWS ONLY";
            }

            else if (_condition.Skip != 0)
            {
                offset = $"OFFSET {_condition.Skip} ROWS";
            }

            return offset;
        }

        #endregion
    }
}