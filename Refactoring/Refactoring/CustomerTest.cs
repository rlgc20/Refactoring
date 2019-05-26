using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    [TestClass()]
    public class CustomerTest
    {
        [TestMethod()]
        public void statementTest()
        {
            Movie KillBill = new Movie("Kill Bill - Vol 1", Movie.REGULAR);
            Movie FindingNemo = new Movie("Procurando Nemo", Movie.CHILDRENS);
            Movie Avengers = new Movie("Vingadores - Guerra Infinita", Movie.NEW_RELEASE);

            Customer cliente = new Customer("Fulano");

            cliente.addRental(new Rental(KillBill, 2));
            cliente.addRental(new Rental(FindingNemo, 2));

            string estado = cliente.statement();

            Assert.IsTrue(estado.Contains("Fulano"));
            Assert.IsTrue(estado.Contains("3.5"));
        }
    }
}
