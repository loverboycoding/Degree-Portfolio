using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentApp;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace StudentTesting
{
    [TestFixture]
    public  class TestStudent
    {
        [Test]
        public void TestMark()
        {
            Student s = new Student();
            s.Mark = 56.5;

            //use assertion to test 
            double actual = s.Mark;
            double expected = 56.5;

            ClassicAssert.AreEqual(actual , expected);
        }
    }
}
