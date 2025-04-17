using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator grade;
        [SetUp]
        public void Setup()
        {
            grade = new GradingCalculator();
        }
        [Test]
        public void Test1()
        {
            grade.Score = 95;
            grade.AttendancePercentage = 90;
            ClassicAssert.AreEqual("A", grade.GetGrade());
        }
        [Test]
        public void Test2()
        {
            grade.Score = 85;
            grade.AttendancePercentage = 90;
            ClassicAssert.AreEqual("B", grade.GetGrade());
        }
        [Test]
        public void Test3()
        {
            grade.Score = 65;
            grade.AttendancePercentage = 90;
            ClassicAssert.AreEqual("C", grade.GetGrade());
        }
        [Test]
        public void Test4()
        {
            grade.Score = 55;
            grade.AttendancePercentage = 90;
            ClassicAssert.AreEqual("F", grade.GetGrade());
        }

        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]

        public void GradingCalculator_CheckingCase_GradeF(int score,int attendance)
        {
            grade.Score = score;
            grade.AttendancePercentage = attendance;

            Assert.That(grade.GetGrade(), Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95,90,ExpectedResult ="A")]
        [TestCase(85,90,ExpectedResult ="B")]
        [TestCase(65,90,ExpectedResult ="C")]
        [TestCase(95,65,ExpectedResult ="B")]
        [TestCase(95,55,ExpectedResult ="F")]
        [TestCase(65,55,ExpectedResult ="F")]
        [TestCase(50,90,ExpectedResult ="F")]

        public string GradingCalculator_CheckAllGrades(int score, int attendance)
        {
            grade.Score = score;
            grade.AttendancePercentage = attendance;

            return grade.GetGrade();
        }



    }
}
