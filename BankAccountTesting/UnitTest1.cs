using BankAccountTesting.Controller;
using BankAccountTesting.Exceptions;

namespace BankAccountTesting
{
    [TestClass]
    public class UnitTest1
    {
        AccountManager _manager = new AccountManager();

        [TestMethod]
        [DataRow(102, 2000)]
        public void DepositeValidAmountIntoValidAccount(int accountNumber, double amount)
        {
            //Action
            var account = _manager.GetAccount(accountNumber);
            double actualBalance = _manager.Deposite(account, amount);

            //Assert
            Assert.AreEqual(_manager.GetBalance(account), actualBalance);
        }


        [TestMethod]
        [DataRow(101, 4000)]

        public void WithdrawValidAmountFromValidAccount(int accountNumber, double amount)
        {
            //Action
            var account = _manager.GetAccount(accountNumber);
            double actualAmount = _manager.Withdraw(account, amount);

            //Assert
            Assert.AreEqual(_manager.GetBalance(account), actualAmount);
        }


        [TestMethod]
        [DataRow(103, 102, 2000)]

        public void TransferValidAmountToValidAccount(int accountNumber1, int accountNumber2, double amount)
        {
            //Action
            var account1 = _manager.GetAccount(accountNumber1);
            var account2 = _manager.GetAccount(accountNumber2);

            double actualBalance = _manager.TransferAmount(account1, account2, amount);

            //Assert
            Assert.AreEqual(_manager.GetBalance(account1), actualBalance);
        }


        [TestMethod]
        [DataRow(101, -10)]

        public void DepositeInvalidAmountInValidAccount(int accountNumber, double amount)
        {
            //Action
            var account = _manager.GetAccount(accountNumber);

            //Assert
            var exception = Assert.ThrowsException<InvalidAmountExcpetion>(()=> _manager.Deposite(account, amount));
            Assert.AreEqual("Invalid amount!! Amount cannot be deposited", exception.Message);
        }


        [TestMethod]
        [DataRow(102, 5000)]
        [DataRow(101, -500)]

        public void WithdawInvalidAmountFromValidAccount(int accountNumber, double amount)
        {
            //Action
            var account = _manager.GetAccount(accountNumber);

            //Assert
            var exception = Assert.ThrowsException<InvalidAmountExcpetion>(() => _manager.Withdraw(account, amount));
            Assert.AreEqual("Amount cannot be withdraw!!", exception.Message);
        }


        [TestMethod]
        [DataRow(102, 103, 5000)]
        public void TransferringInValidAmountToValidAccount(int accountNumber1, int accountNumber2, double amount)
        {
            //Action
            var account1 = _manager.GetAccount(accountNumber1);
            var account2 = _manager.GetAccount(accountNumber2);

            //Assert
            var exception = Assert.ThrowsException<InvalidAmountExcpetion>(() => _manager.TransferAmount(account1, account2, amount));
            Assert.AreEqual("Amount cannot be withdraw!!", exception.Message);
        }


        [TestMethod]
        [DataRow(102, 105, 2000)]
        public void TransferringValidAmountToInvalidAccount(int accountNumber1, int accountNumber2, double amount)
        {
            //Action
            var account1 = _manager.GetAccount(accountNumber1);

            //Assert
            var exception2 = Assert.ThrowsException<InvalidAccountException>(() => _manager.GetAccount(accountNumber2));
            Assert.AreEqual("No such account exist!!", exception2.Message);
        }
    }
}