using AdminApp_YchetSotrudnikov;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsConnected_ruturnedTrue()
        {
            bool result = false;
            if (AdminApp_YchetSotrudnikov.IS_YchetSotrudnikovYpravleniePersonalomEntities.GetContext() != null)
                result = true;
            Assert.IsTrue(result);
        }
    }
}
