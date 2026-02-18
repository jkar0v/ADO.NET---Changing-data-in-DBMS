using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class DatabaseHelper
    {
        private string connectionString =
           "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable GetBooks()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Title, Author, Price FROM Books";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(table);
            }

            return table;
        }

        public void InsertBook(string title, string author, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Books (Title, Author, Price) VALUES (@title, @author, @price)";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(query, conn);

                adapter.InsertCommand.Parameters.AddWithValue("@title", title);
                adapter.InsertCommand.Parameters.AddWithValue("@author", author);
                adapter.InsertCommand.Parameters.AddWithValue("@price", price);

                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
