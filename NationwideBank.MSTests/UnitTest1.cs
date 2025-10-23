using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationwideBank;

namespace NationwideBank.MSTests
{
    [TestClass]
    public class BankAccountTests
    {
        private static BankAccount MakeSavings(decimal opening)
            => new BankAccount("User", "Savings", opening);

        private static BankAccount MakeCurrent(decimal opening)
            => new BankAccount("User", "Current", opening);

        [TestMethod]
        public void Constructor_PositiveOpening_SetsBalance()
        {
            var acc = MakeSavings(500m);
            Assert.AreEqual(500m, acc.Balance);
            Assert.AreEqual("Savings", acc.AccountType);
            Assert.AreEqual("User", acc.AccountHolder);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-10)]
        public void Constructor_NonPositiveOpening_DefaultsToOne(decimal opening)
        {
            var acc = MakeSavings(opening);
            Assert.AreEqual(1m, acc.Balance);
        }

        [TestMethod]
        public void Credit_Positive_IncreasesBalance()
        {
            var acc = MakeCurrent(100m);
            acc.Credit(50m);
            Assert.AreEqual(150m, acc.Balance);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        public void Credit_NonPositive_NoChange(decimal amount)
        {
            var acc = MakeCurrent(100m);
            acc.Credit(amount);
            Assert.AreEqual(100m, acc.Balance);
        }

        [TestMethod]
        public void Debit_Valid_DecreasesBalance()
        {
            var acc = MakeCurrent(200m);
            acc.Debit(50m);
            Assert.AreEqual(150m, acc.Balance);
        }

        [TestMethod]
        public void Debit_TooMuch_NoChange()
        {
            var acc = MakeCurrent(100m);
            acc.Debit(150m);
            Assert.AreEqual(100m, acc.Balance);
        }

        [TestMethod]
        public void Savings_CannotGoBelowOne()
        {
            var acc = MakeSavings(100m);
            acc.Debit(99m);   // OK → leaves £1
            Assert.AreEqual(1m, acc.Balance);

            acc.Debit(1m);    // would drop to £0 → blocked
            Assert.AreEqual(1m, acc.Balance);
        }
    }
}
