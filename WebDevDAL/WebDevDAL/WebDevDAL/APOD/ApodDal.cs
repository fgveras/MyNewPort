using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebDevDAL.APOD
{
    public class ApodDal
    {
        private protected string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=apod_db;Trusted_Connection=True;TrustServerCertificate=True;";

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

        public int Create(string copyright, DateTime date, string explanation, string hdurl, string media_type, string service_version, string title, string url)
        {

            int defaultId = 0;

            string command = $@"
                INSERT INTO apod 
                    (copyright, date, explanation, hdurl, media_type, service_version, title, url) 
                OUTPUT INSERTED.Id
                VALUES 
                    (@copyright, @date, @explanation, @hdurl, @media_type, @service_version, @title, @url) ";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {

                    cmd.Parameters.AddWithValue("@copyright", copyright);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@explanation", explanation);
                    cmd.Parameters.AddWithValue("@hdurl", hdurl);
                    cmd.Parameters.AddWithValue("@media_type", media_type);
                    cmd.Parameters.AddWithValue("@service_version", service_version);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@url", url);

                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (!(result is null))
                    {
                        return Convert.ToInt32(result);    
                    }

                }
            }

            return defaultId;
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
