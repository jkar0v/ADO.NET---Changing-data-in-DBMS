using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB
{
    internal class StudentRepository
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Student student = new Student
                    {
                        Id = (int)row["Id"],
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString()
                    };

                    students.Add(student);
                }
            }

            return students;
        }

        public void Insert(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (FirstName, LastName) VALUES (@firstName, @lastName)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@firstName", student.FirstName);
                command.Parameters.AddWithValue("@lastName", student.LastName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
