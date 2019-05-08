using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CommonRepository
    {
        private string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected DataTable ExecuteQuery(string sql)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            using (SqlDataAdapter dap = new SqlDataAdapter(com))
            {
                dap.Fill(dataTable);
            }

            return dataTable;
        }

        protected int ExecuteNonQuery(string sql)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();

                rowsAffected = com.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        protected int ExecuteNonQueryScalar(string sql)
        {
            int numberToReturn = 0;

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                con.Open();

                numberToReturn = (int)com.ExecuteScalar();
            }

            return numberToReturn;
        }

        protected void BulkInsert(DataTable dataTable)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conString))
            {
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = dataTable.TableName;
                bulkCopy.WriteToServer(dataTable);
            }
        }
    }
}
