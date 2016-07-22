using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private const int maxStudentCount = 30;
        private IList<Student> setOfStudents;

        public Course(ICollection<Student> studentList)
        {
            this.SetOfStudents = studentList;
        }

        public ICollection<Student> SetOfStudents
        {
            get { return this.setOfStudents; }
            set
            {
                if (value.Count < maxStudentCount)
                {
                    this.setOfStudents = new List<Student>(value);
                }
            }
        }

        public void Join(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException("NULL student is not allowed!");
            }
            if (this.setOfStudents.Count <= maxStudentCount - 1)
            {
                this.setOfStudents.Add(student);
            }
        }

        public void Leave(Student student)
        {
            var index = setOfStudents.IndexOf(student);
            if (index == -1)
            {
                throw new ArgumentException("Student not found. Can not be removed.");
            }
            setOfStudents.RemoveAt(index);
        }
    }
}
