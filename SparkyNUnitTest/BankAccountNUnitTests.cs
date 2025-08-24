using Moq;
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
    public class BankAccountNUnitTests
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
           
        }
        [Test]
        // here we are checking the test of bankAccount onject as well as LogBook object . so it is not Unit test more
        // it is kind of integration test.

        public void BankDepositFakeLogger_Add100_ReturnTrue()
        {
           BankAccount bankAccount = new BankAccount(new LogFakker());
            bool result = bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100)); 
        }
        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
           BankAccount bankAccount = new BankAccount(logMock.Object);
            bool result = bankAccount.Deposit(100);
            Assert.That(result, Is.True);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100)); 
        }

    }
}
