using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace Tests
{
    [TestClass]
    public class StudentTests
    {
        private const int minStudentNumber = 10000;
        private const int maxStudentNumber = 99999;

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NamePropertyShouldThrowNullRefferenceExceptionIfEmtyOrNullStringIsPassed()
        {
            var student = new Student("Johny", minStudentNumber);

            student.Name = "";
        }

        [TestMethod]
        public void NamePropertyShouldReturnExpectedStringIfValidOneIsPassed()
        {
            var expectedName = "Johny";
            var student = new Student(expectedName, minStudentNumber);
            var actualName = student.Name;
            Assert.AreEqual(expectedName, actualName);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberPropertyShouldThrowArgumentOutOfRangeExceptionIfLowerNumberThanMinAllowedIsPassed()
        {
            var student = new Student("Pesho", minStudentNumber);

            student.Number = minStudentNumber - 1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberPropertyShouldThrowArgumentOutOfRangeExceptionIfGreaterNumberThanMaxAllowedIsPassed()
        {
            var student = new Student("Pesho", maxStudentNumber);

            student.Number = maxStudentNumber + 1;
        }

        [TestMethod]
        public void NumberPropertyShouldReturnExpectedNumberIfValidNumberIsPassed()
        {
            var expextedNumber = 10001;
            var student = new Student("Pesho", expextedNumber);
            var actualNumber = student.Number;

            Assert.AreEqual(expextedNumber, actualNumber);
        }
    }
}
