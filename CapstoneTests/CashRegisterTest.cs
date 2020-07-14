using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests.Test
{
    [TestClass]
    public class CashRegisterTest
    {


        [TestMethod]
        public void ChangeTest1()
        {
            //arrange

            CashRegister getChange = new CashRegister();
            decimal MoneyInputed = 3.60M;
            string expected = $"number of quarters: 14  number of dimes: 1";

            //act

            string actual = "";
            actual = getChange.Change(MoneyInputed);

            //assert

            Assert.AreEqual(expected, actual, "wrong.");

        }

    }
}
