using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NamePropertyShouldThrowNullRefferenceExceptionIfEmtyOrNullStringIsPassed()
        {
            var student = new Student("Pesho", 10000);

            student.Name = "";
        }

        [TestMethod]
        public void NamePropertyShouldReturnExpectedStringIfValidOneIsPassed()
        {
            var expectedName = "Pesho";
            var student = new Student(expectedName, 10000);
            var actualName = student.Name;
            Assert.AreEqual(expectedName, actualName);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberPropertyShouldThrowArgumentOutOfRangeExceptionIfLowerNumberThanMinAllowedIsPassed()
        {
            var min = 10000;
            var student = new Student("Pesho", min);

            student.Number = min - 1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberPropertyShouldThrowArgumentOutOfRangeExceptionIfGreaterNumberThanMaxAllowedIsPassed()
        {
            var max = 99999;
            var student = new Student("Pesho", max);

            student.Number = max + 1;
        }

        [TestMethod]
        public void NumberPropertyShouldReturnExpextedNumberIfValidNumberIsPassed()
        {
            var expextedNumber = 10001;
            var student = new Student("Pesho", expextedNumber);
            var actualNumber = student.Number;

            Assert.AreEqual(expextedNumber, actualNumber);
        }
    }
}
