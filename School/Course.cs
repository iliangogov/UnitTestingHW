using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private const int maxStudentCount = 29;
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
                if (value.Count <= maxStudentCount)
                {
                    this.setOfStudents = new List<Student>(value);
                }
                else
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Student list must contain up to {0} students", maxStudentCount));
                }
            }
        }

        public void Join(Student student)
        {
            if (student == null)
            {
                throw new NullReferenceException("NULL student is not allowed!");
            }
            if (this.setOfStudents.Count <= maxStudentCount - 1)
            {
                this.setOfStudents.Add(student);
            }
            else
            {
                throw new IndexOutOfRangeException("Student list is already full");
            }
        }

        public void Leave(Student student)
        {
            var index = setOfStudents.IndexOf(student);
            if (index == -1)
            {
                throw new IndexOutOfRangeException("Student not found. Can not be removed.");
            }
            setOfStudents.RemoveAt(index);
        }
    }
}
