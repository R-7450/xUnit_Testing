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
     public class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]  // used to initialise Customer object globally.

        public void SetUp()
        {
            customer= new Customer();
        }
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
           //Assert.multiple wraps multiple assert statement, which should all be executed even if the fail

             customer.GreetAndCombineNmaes("Rohit","Gandhi");

            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Rohit Gandhi"));
                ClassicAssert.AreEqual(customer.GreetMessage, "Hello, Rohit Gandhi");// you can also use th,is
                Assert.That(customer.GreetMessage, Does.Contain("Rohit Gandhi"));
                Assert.That(customer.GreetMessage, Does.StartWith("Hello, "));
                Assert.That(customer.GreetMessage, Does.EndWith("Gandhi"));
                Assert.That(customer.GreetMessage, Does.Contain("rohit Gandhi").IgnoreCase);
            });

           


        }
        [Test]

        public void GreetMessage_NotGreeted_ReturnNull()
        {
            

            ClassicAssert.IsNull(customer.GreetMessage);
        }
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNmaes("Rohit", "");
            ClassicAssert.IsNotNull(customer.GreetMessage);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));

        }
        [Test]

        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var  ExceptionDetails = Assert.Throws<ArgumentException>(() => { customer.GreetAndCombineNmaes("", "Gandhi"); });
            ClassicAssert.AreEqual("Empty first name", ExceptionDetails.Message);

        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }



    }
}
