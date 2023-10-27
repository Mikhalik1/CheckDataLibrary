using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CheckDataLibrary;
using Microsoft.Win32;

namespace CheckDataLibraryTest
{
    [TestClass]
    public class VinCheckTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string vin = "JHMCM56557Cq04453";
            int ya = 2014;
            VinCheck ck = new VinCheck();
            bool result = ck.CheckVin(vin,ya);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod1_a()
        {
            string vin = "JHMCM56557C404453";
            int ya = 2014;
            VinCheck ck = new VinCheck();
            bool result = ck.CheckVin(vin, ya);
            Assert.IsTrue(result);
        }
    }
}
