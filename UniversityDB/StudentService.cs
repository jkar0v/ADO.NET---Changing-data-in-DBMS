using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB
{
    internal class StudentService
    {
        private StudentRepository repository = new StudentRepository();

        public List<Student> GetAll()
        {
            return repository.GetAll();
        }

        public void Insert(string name, string lname)
        {
            Student student = new Student
            {
                FirstName = name,
                LastName = lname
            };
            repository.Insert(student);
        }

        public int GetStudentsCount()
        {
            return repository.GetAll().Count;
        }
    }
}
