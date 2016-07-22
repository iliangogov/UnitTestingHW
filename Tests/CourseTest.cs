using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using School;

namespace Tests
{
    [TestClass]
    public class CourseTest
    {
        private const int maxStudentCount = 29;

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetOfStudentsMustThrowIndexOutOfRangeExceptionIfListWithStudentsPassedHasBiggerCountThanAllowed()
        {
            var setOfStudents = setOfStudentsGenerator(maxStudentCount+1);
            var course = new Course(setOfStudents);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void JoinMethodMustThrowNullReferenceExceptionIfNullStudentIsToBeAdded()
        {
            var setOfStudents = setOfStudentsGenerator(20);
            var course = new Course(setOfStudents);

            course.Join(null);

        }

        [TestMethod]
        public void JoinMethodMustAddStudentInSetOfStudentsIfmaxStudentCountIsNotExceeded()
        {
            var setOfStudents = setOfStudentsGenerator(20);
            var course = new Course(setOfStudents);
            var student = new Student("Johny", 10022);
            var studentsCountBeforeJoin = course.SetOfStudents.Count;
            var expectedStudentsAfterJoin = studentsCountBeforeJoin+1;

            course.Join(student);
            var actualStudentsCount= course.SetOfStudents.Count;

            Assert.AreEqual(expectedStudentsAfterJoin, actualStudentsCount);

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void JoinMethodMustThrowIndexOutOfRangeExceptionIfmaxStudentCountIsExceeded()
        {
            var setOfStudents = setOfStudentsGenerator(maxStudentCount);
            var course = new Course(setOfStudents);
            var student = new Student("Johny", 10030);
          
            course.Join(student);
          
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LeaveMethodMustThrowIndexOutOfRangeExceptionIfPassedStudentIsNotFoundInTheList()
        {
            var setOfStudents = setOfStudentsGenerator(maxStudentCount);
            var course = new Course(setOfStudents);
            var student = new Student("Johny", 10030);

            course.Leave(student);
        }

        [TestMethod]
        public void LeaveMethodShouldRemoveStudentIfSuchIsExistingInTheList()
        {
            var student = new Student("Johny", 10030);
            var anotherStudent = new Student("Michael", 10040);
            var list = new List<Student>();
            list.Add(student);
            list.Add(anotherStudent);
            var course = new Course(list);
            var courseStudentListBeforeLeaving = course.SetOfStudents.Count;

            course.Leave(student);
            var courseStudentListAfterLeaving = course.SetOfStudents.Count;

            Assert.AreNotEqual(courseStudentListBeforeLeaving, courseStudentListAfterLeaving);
        }

        private List<Student> setOfStudentsGenerator(int count)
        {
            var list = new List<Student>();
            for(int i=0;i<count;i++)
            {
                var student = new Student(i.ToString(), i + 10000);
                list.Add(student);
            }
            return list;
        }
    }
}
