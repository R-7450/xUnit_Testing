using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
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
    public class CalculatorNUnitTests
    {
        private Calculator calc;
        // Arrange
        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }
        [Test]
        public void AddTwoNumbers_InputTwoInt_GetCorrectAddition()
        {
     

            // Act

            int result = calc.AddNumbers(10, 20);

            // Assert

            ClassicAssert.AreEqual(30,result);
        }
        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
         

            // Act

            bool isOdd = calc.IsOddNumber(6);

            // Assert

            Assert.That(isOdd,Is.EqualTo(false));
            ClassicAssert.IsFalse(isOdd); // you can also use this logic;
        }

        // if we have to test for multiple values 
        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue( int a)
        {
         

            // Act

            bool isOdd = calc.IsOddNumber(a);

            // Assert

            Assert.That(isOdd,Is.EqualTo(true));
            ClassicAssert.IsTrue(isOdd);// you can also use this logic;


        }
        // combining  unit test with expected result 
        [Test]
        [TestCase(11,ExpectedResult =true)]
        [TestCase(12,ExpectedResult =false)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
       

            
            return calc.IsOddNumber(a);

            


        }
        [Test]
        [TestCase(5.4,4.8,ExpectedResult =10.2)]
        [TestCase(5.2,4.2,ExpectedResult =9.4)]
        [TestCase(5.48,3.88,ExpectedResult =9.36)]

        public double AddTwoNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            

            // Act

            return calc.AddNumbersDouble(a,b);

        
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new() { 5, 7, 9 };
            List<int> result = calc.GetOddRnge(5, 10);
            Assert.That(result, Is.EqualTo(expectedOddRange));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
            Assert.That(result.Count, Is.EqualTo(3));
            
           // ClassicAssert.AreEqual(expectedOddRange, result);
           // ClassicAssert.Contains(7, result);


        }

    }
}
