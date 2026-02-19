using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB
{
    internal class CourseService
    {
        private CourseRepository repository = new CourseRepository();

        public List<Course> GetAll()
        {
            return repository.GetAll();
        }

        public void Insert(string cname, int credits)
        {
            Course course = new Course
            {
                CourseName = cname,
                Credits = credits
            };
            repository.Insert(course);
        }
    }
}
