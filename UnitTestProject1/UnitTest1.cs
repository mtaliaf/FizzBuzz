using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FizzBuzzLib;

namespace FizzBuzzTest
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FizzBuzz fb = new FizzBuzz();
            List<string> result = fb.filter(100);

            Assert.AreEqual(100, result.Count);
        }
    }
}
