using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB
{
    internal class CourseRepository
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Course course = new Course
                    {
                        Id = (int)row["Id"],
                        CourseName = row["CourseName"].ToString(),
                        Credits = (int)row["Credits"]
                    };

                    courses.Add(course);
                }
            }

            return courses;
        }

        public void Insert(Course course)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Courses (CourseName, Credits) VALUES (@name, @credits)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", course.CourseName);
                command.Parameters.AddWithValue("@credits", course.Credits);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        }
}
