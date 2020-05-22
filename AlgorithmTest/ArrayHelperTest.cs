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

        [TestMethod]
        public void CheckPossibilityTest()
        {
            var array = new int[] { 1};
            var output = ArrayHelper.CheckPossibility(array);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void ReverseNumberTest()
        {
            var output = ArrayHelper.ReverseNumber(1534236469);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void FindPivotTest()
        {
            var array = new int[] { 1, 7, 3, 6, 5, 6 };
            var output = ArrayHelper.FindPivotIndex(array);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void Sort012Test()
        {
            var array = new int[] { 0, 1, 2, 0, 1, 2 };
            var output = ArrayHelper.Sort012(array);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void MajorityElementTest()
        {
            var array = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var output = ArrayHelper.MajorityElement(array);
            Assert.IsNotNull(output);
        }
    }
}
