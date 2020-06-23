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
        public void TwoNumberSumIndexTest()
        {
            var array = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789};
            var output = ArrayHelper.TwoNumberSumIndex(array, 542);
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
            var array = new int[] { 0,0,0 };
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

        [TestMethod]
        public void SearchSortedShiftedTest()
        {
            var array = new int[] { 1,3 };
            var output = ArrayHelper.SearchSortedShifted(array,3);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void SearchRangeTest()
        {
            // 5, 7, 7, 8, 8, 10
            var array = new int[] { 1 };
            var output = ArrayHelper.SearchRange(array,0);
            Assert.IsNotNull(output);
        }
    }
}
