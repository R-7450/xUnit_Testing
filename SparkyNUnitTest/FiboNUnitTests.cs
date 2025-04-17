using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class FiboNUnitTests
    {
        private Fibo fibo;
        [SetUp]
        public void SetUp()
        {
            fibo = new Fibo();
        }
        [Test]

        public void FiboTest_Range_1()
        {
            List<int> expected = new List<int>(){0};
            fibo.Range = 1;
            List<int> result = fibo.GetFiboSeries();
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result,Is.Not.Empty);
            Assert.That(result, Is.Ordered);

        }
        [Test]
        public void FiboTest_Range_6()
        {
            List<int> ExpectedSeries= new List<int>() {0,1,1,2,3,5};
            fibo.Range = 6;
            List<int> result = fibo.GetFiboSeries();
            Assert.That(result,Does.Contain(3));
            Assert.That(result,Does.Not.Contain(4));
            Assert.That(result.Count,Is.EqualTo(6));
            Assert.That(result, Is.EqualTo(ExpectedSeries));
            

        }

    }
}
