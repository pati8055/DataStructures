using Algorithms.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTest
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void TwoNumberSumTest()
        {           
            var output = StringHelper.BuddyStrings("a", "a");
            Assert.IsNotNull(output);
        }

    }
}
