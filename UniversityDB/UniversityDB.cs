using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityDB
{
    public partial class UniversityDB : Form
    {
        private StudentService studentService = new StudentService();
        private CourseService courseService = new CourseService();
        public UniversityDB()
        {
            InitializeComponent();
        }

        private void UniversityDB_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadCourses();

            Clear();
        }

        private void LoadStudents()
        {
            dgvStudents.DataSource = studentService.GetAll();
            lblCount.Text = "Students count: " + studentService.GetStudentsCount();
        }

        private void LoadCourses()
        {
            dgvCourses.DataSource = courseService.GetAll();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;

            studentService.Insert(FirstName, LastName);
            LoadStudents();
            Clear();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            string CourseName = txtCourseName.Text;
            int Credits = (int)numCredits.Value;

            courseService.Insert(CourseName, Credits);
            LoadCourses();
            Clear();
        }

        private void Clear()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCourseName.Clear();
        }
    }
}
