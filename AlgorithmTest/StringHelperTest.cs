﻿using Algorithms.Strings;
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

        [TestMethod]
        public void GroupAnagramsTest()
        {
            var input = new List<string>
            {
             "yo", "act", "flop", "tac", "cat", "oy", "olfp"
            };
            var output = StringHelper.GroupAnagrams(input);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void FindSubstringIndexTest()
        {
            var output = StringHelper.FindSubstringIndex("hello", "ll");
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void FrequencySortTest()
        {
            var output = StringHelper.FrequencySort("tree");
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void NumJewelsInStonesTest()
        {
            var output = StringHelper.NumJewelsInStones("z", "ZZ");
            Assert.IsNotNull(output);
        }


        [TestMethod]
        public void UniqueStringMappingTest()
        {
            var output = StringHelper.UniqueStringMapping("abc", "xyz");
            Assert.IsTrue(output);

            output = StringHelper.UniqueStringMapping("foo", "far");
            Assert.IsFalse(output);

            output = StringHelper.UniqueStringMapping("folo", "far");
            Assert.IsTrue(output);

            output = StringHelper.UniqueStringMapping("xyz", "abcdef");
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void LengthOfLongestSubstringTest()
        {
            var output = StringHelper.LengthOfLongestSubstringLength("pwwkew");
            Assert.IsTrue(output > 0);
        }
    }
}
