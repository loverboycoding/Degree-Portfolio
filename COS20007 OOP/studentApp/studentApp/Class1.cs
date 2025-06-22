using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentApp
{
    public class Student
    {
        private string name;
        private double mark;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Mark
        {
            get { return mark; }
            set { mark = value; }
        }
    }
}