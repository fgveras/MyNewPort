using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace WebDevDAL
{
    public class DataAccess
    {

        private protected string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=finnas_db;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable Query(string command)
        {
            var dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {                        
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void Create(string command)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {                    

                }
            }
        }

        private void Update()
        {

        }

        private void Delete()
        {

        }

        public List<Dictionary<string, object>> ToList(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }

                list.Add(dict);
            }

            return list;
        }

    }
}
