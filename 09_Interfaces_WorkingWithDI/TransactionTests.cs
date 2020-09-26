﻿using System;
using _09_Interfaces_WorkingWithDI.Currency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _09_Interfaces_WorkingWithDI.Currency.Penny;

namespace _09_Interfaces_WorkingWithDI
{
    [TestClass]
    public class TransactionTests
    {
        private decimal _debt;

        private void PayDebt(ICurrency payment)
        {
            _debt -= payment.Value;
            Console.WriteLine($"You have paid {payment.Value} towards your debt. Congrats!");
        }
        [TestInitialize]
        public void Arrage()
        {
            _debt = 42000m;
        }
        [TestMethod]
        public void PayDebtTest()
        {
            PayDebt(new Dollar());
            PayDebt(new Dime());
            PayDebt(new ElectronicPayment(35000.50m));
            decimal expectedDebt = 4200m - 35001.6m;
            Assert.AreEqual(expectedDebt, _debt);
        }
        [TestMethod]
        public void InjectingIntoContructors()
        {
            var dollar = new Dollar();
            var epayment = new ElectronicPayment(52000m);
            var firstTransaction = new Transaction(dollar);
            var secondTransaction = new Transaction(epayment);
            Console.WriteLine(firstTransaction.GetTransactionAmount());
            Console.WriteLine(secondTransaction.GetTransactionAmount());
        }
    }
}