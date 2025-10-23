using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationwideBank;

namespace NationwideBank.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        // AAA pattern: Arrange, Act, Assert

        [TestMethod]
        public void CreateAccount_Savings_ZeroOpening_SetsBalanceToOne()
        {
            // Arrange
            var acc = new BankAccount();

            // Act
            acc.CreateAccount("Tejas", "Savings", 0);

            // Assert
            Assert.AreEqual(1.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void CreateAccount_Current_PositiveOpening_UsesThatBalance()
        {
            var acc = new BankAccount();

            acc.CreateAccount("Tejas", "Current", 500);

            Assert.AreEqual(500.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Credit_PositiveAmount_IncreasesBalance()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Current", 100);

            acc.Credit(50);

            Assert.AreEqual(150.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Credit_NonPositiveAmount_DoesNotChangeBalance()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Current", 100);

            acc.Credit(0);
            Assert.AreEqual(100.0, acc.Balance, 0.0001);

            acc.Credit(-20);
            Assert.AreEqual(100.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Debit_ValidAmount_DecreasesBalance()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Current", 200);

            acc.Debit(50);

            Assert.AreEqual(150.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Debit_MoreThanBalance_DoesNotChangeBalance()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Current", 100);

            acc.Debit(150);

            Assert.AreEqual(100.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Debit_NonPositive_DoesNotChangeBalance()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Current", 100);

            acc.Debit(0);
            Assert.AreEqual(100.0, acc.Balance, 0.0001);

            acc.Debit(-10);
            Assert.AreEqual(100.0, acc.Balance, 0.0001);
        }

        [TestMethod]
        public void Debit_Savings_CannotDropBelowOne()
        {
            var acc = new BankAccount();
            acc.CreateAccount("Tejas", "Savings", 50);

            // Try to take enough to go below £1
            acc.Debit(49.50);

            // Should be blocked by rule: cannot go below £1
            Assert.AreEqual(50.0, acc.Balance, 0.0001);
        }
    }
}
