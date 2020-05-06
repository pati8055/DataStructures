using Algorithms.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmTest
{
    [TestClass]
    public class ArrayHelperTest
    {
        [TestMethod]
        public void TwoNumberSumTest()
        {
            var array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
            var output = ArrayHelper.TwoNumberSum(array, 10);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TwoNumberSumListTest()
        {
            var array = new int[] { 5, 5, -4, 14, 6, 4, 12, 6 };
            var output = ArrayHelper.TwoNumberSumList(array, 10);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void ThreeNumberSumTest()
        {
            var array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
            var output = ArrayHelper.ThreeNumberSum(array, 0);
            Assert.IsNotNull(output);
        }
    }
}
