using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Walter White", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.0;
            BankAccount account = new BankAccount("Mr. Jesse Pinkman", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            // This method causes the test to fail unless an ArgumentOutOfRangeException is thrown.
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //// Arrange
            //double beginningBalance = 11.99;
            //double debitAmount = 20.0;
            //BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //// Act
            //try
            //{
            //    account.Debit(debitAmount);
            //}
            //catch (System.ArgumentOutOfRangeException e)
            //{
            //    // Assert
            //    StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            //}

            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Piotr Zelinski", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            // Fail Assert at the end to handle the case where there is not exception thrown. 
            Assert.Fail("The expected exception was not thrown.");
        }

    }
}
