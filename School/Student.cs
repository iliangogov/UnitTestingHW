using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private const int minUniqueNumber = 10000;
        private const int maxUniqueNumber = 99999;

        private string name;
        private int number;
        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        //unique number is between 10000 and 99999
        public int Number
        {
            get { return this.number; }
            set
            {
                if (!(value < minUniqueNumber || value > maxUniqueNumber))
                {
                    this.number = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
