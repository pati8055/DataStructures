using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Algorithms.Arrays
{
    public static class ArrayHelper
    {
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int currentSum = array[left] + array[right];

                if (currentSum == targetSum)
                {
                    return new int[] { array[left], array[right] };
                }
                else if (currentSum > targetSum)
                {
                    right--;
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
            }

            return new int[0];
        }

        public static int[] TwoNumberSumIndex(int[] nums, int target)
        {
            int[] result = new int[2];
            if (nums == null || nums.Length == 0)
            {
                return result;
            }           

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int potentialMatch = target - nums[i];
                if (map.ContainsKey(potentialMatch))
                {
                    return new int[] { map[potentialMatch], i };                    
                }
                else
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        continue;
                    }
                    map.Add(nums[i], i);
                }   
            }

            return result;
        }

        /// <summary>
        /// Returns Multiple Matches in a Array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static List<int[]> TwoNumberSumList(int[] array, int targetSum)
        {
            Array.Sort(array);
            List<int[]> numberSum = new List<int[]>();
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int currentSum = array[left] + array[right];

                if (currentSum == targetSum)
                {
                    numberSum.Add(new int[] { array[left], array[right] });
                    left++;
                    right--;
                }
                else if (currentSum > targetSum)
                {
                    right--;
                }
                else if (currentSum < targetSum)
                {
                    left++;
                }
            }

            return numberSum;
        }

        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            List<int[]> numberSum = new List<int[]>();

            for (int i = 0; i < array.Length - 2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;

                while (left < right)
                {
                    int currentSum = array[i] + array[left] + array[right];

                    if (currentSum == targetSum)
                    {
                        numberSum.Add(new int[] { array[i], array[left], array[right] });
                        left++;
                        right--;
                    }
                    else if (currentSum < targetSum)
                    {
                        left++;
                    }
                    else if (currentSum > targetSum)
                    {
                        right--;
                    }
                }
            }

            return numberSum;
        }

        public static int GetNthFib(int n)
        {
            int i = 1;
            int j = 0;
            int count = 1;
            int nextFib = 0;
            while (count < n)
            {
                nextFib = i + j;
                i = j;
                j = nextFib;
                count++;
            }
            return nextFib;
        }

        public static int ReverseNumber(int x)
        {
            bool isNegativeNumber = false;
            if (x < 0)
            {
                isNegativeNumber = true;
                x *= -1;
            }
            long reverseNumber = 0;
            while (x > 0)
            {
                reverseNumber = (reverseNumber * 10) + (x % 10);
                x /= 10;
            }
            if (reverseNumber > int.MaxValue)
            {
                return 0;
            }
            return isNegativeNumber ? (int)(-1 * reverseNumber) : (int)reverseNumber;
        }

        public static bool IsPalindromeNumber(int x)
        {

            if (x == 0)
            {
                return true;
            }

            if (x < 0 || x % 10 == 0)
            {
                return false;
            }

            int reversedNumber = 0;
            while (x > reversedNumber)
            {
                reversedNumber = reversedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            return x == reversedNumber || x == reversedNumber / 10;
        }


        //TODO: This is work in Progress - Still have to find the solution
        /// <summary>
        /// Check for Increasing Array with One Change
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 1)
            {
                return true;
            }

            int modifiedCount = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1] && modifiedCount > 1)
                {
                    return false;
                }
                else if (nums[i] > nums[i + 1])
                {
                    if (i > 0 && nums[i - 1] > nums[i + 1])
                    {
                        nums[i + 1] = nums[i];
                    }
                    modifiedCount++;
                }
            }

            return modifiedCount == 1;
        }

        public static int ThirdMaxNumber(int[] nums)
        {
            int? max = null;
            int? secondMax = null;
            int? thirdmax = null;

            foreach (var num in nums)
            {
                if (num.Equals(max) || num.Equals(secondMax) || num.Equals(thirdmax))
                {
                    continue;
                }

                if (max == null || num > max)
                {
                    thirdmax = secondMax;
                    secondMax = max;
                    max = num;
                }
                else if (secondMax == null || num > secondMax)
                {
                    thirdmax = secondMax;
                    secondMax = num;
                }
                else if (thirdmax == null || num > thirdmax)
                {
                    thirdmax = num;
                }
            }

            if (thirdmax == null)
            {
                return max.GetValueOrDefault();
            }
            return thirdmax.GetValueOrDefault();
        }

        public static int FindPivotIndex(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int totalSum = 0;
            int leftSum = 0;

            foreach (var num in nums)
            {
                totalSum += num;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == totalSum - nums[i] - leftSum)
                {
                    return i;
                }

                leftSum += nums[i];
            }

            return -1;
        }

        public static int[] Sort012(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums;
            }

            int start = 0; //To keep track of 0's
            int end = nums.Length - 1; //keep track of 2's
            int currentIndex = 0;

            while (currentIndex <= end)
            {
                if (nums[currentIndex] == 0)
                {
                    Swap(nums, start, currentIndex);
                    start++;
                    currentIndex++;
                }
                else if (nums[currentIndex] == 1)
                {
                    currentIndex++;
                }
                else
                {
                    Swap(nums, end, currentIndex);
                    end--;
                }
            }

            return nums;
        }

        public static int MajorityElement(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int targetLenght = nums.Length / 2;

            Dictionary<int, int> numCountMap = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (numCountMap.ContainsKey(num))
                {
                    numCountMap[num] += 1;

                    if (numCountMap[num] > targetLenght)
                    {
                        return num;
                    }
                }
                else
                {
                    numCountMap.Add(num, 1);
                }
            }

            return -1;


        }

        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            if (array.Count == 0 || sequence.Count == 0)
            {
                return false;
            }

            int arrayIndex = 0, sequenceIndex = 0;

            while (arrayIndex < array.Count && sequenceIndex < sequence.Count)
            {
                if (array[arrayIndex] == sequence[sequenceIndex])
                {
                    sequenceIndex++;
                }
                arrayIndex++;

            }
            return sequenceIndex == sequence.Count;
        }

        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            int arrayOneIndex = 0;
            int arrayTwoIndex = 0;
            int smallestDiff = int.MaxValue;
            int currentDiff = int.MaxValue;
            int[] smallestPair = new int[2];

            while (arrayOneIndex < arrayOne.Length && arrayTwoIndex < arrayTwo.Length)
            {
                int firstnum = arrayOne[arrayOneIndex];
                int secondnum = arrayTwo[arrayTwoIndex];

                if (firstnum < secondnum)
                {
                    currentDiff = secondnum - firstnum;
                    arrayOneIndex++;
                }
                else if (secondnum < firstnum)
                {
                    currentDiff = firstnum - secondnum;
                    arrayTwoIndex++;
                }
                else
                {
                    return new int[] { firstnum, secondnum };
                }

                if (smallestDiff > currentDiff)
                {
                    smallestDiff = currentDiff;
                    smallestPair = new int[] { firstnum, secondnum };
                }

            }

            return smallestPair;
        }

        public static List<int> MoveElementToEnd(List<int> array, int toMove)
        {
            if (array.Count == 0)
            {
                return new List<int>();
            }
            int start = 0;
            int end = array.Count - 1;

            while (start < end)
            {
                if (array[end] == toMove)
                {
                    end--;
                    continue;
                }

                if (array[start] == toMove)
                {
                    Swap(array, start, end);
                    end--;
                }
                start++;
            }
            return array;
        }

        public static int BinarySearch(int[] array, int target)
        {
            if (array.Length == 0)
            {
                return -1;
            }

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                int potentialmatch = array[middle];
               
                if (potentialmatch == target)
                {
                    return middle;
                }
                else if (target > potentialmatch)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public static int SearchSortedShifted(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            //[4,5,6,7,0,1,2]
            int startIndex = FindMiddleIndex(nums); //finds the minum element in Array

            int left = 0;
            int right = nums.Length - 1;

            if (target >= nums[startIndex] && target <= nums[right])
            {
                left = startIndex;
            }
            else
            {
                right = startIndex;
            }

            while (left <= right)
            {
                int midpoint = (left + right) / 2;

                if (target == nums[midpoint])
                {
                    return midpoint;
                }
                else if (target > nums[midpoint])
                {
                    left = midpoint + 1;
                }
                else
                {
                    right = midpoint - 1;
                }
            }

            return -1;
        }

        private static int FindMiddleIndex(int[] nums)
        {
            int startIndex = 0;
            int endIndex = nums.Length - 1;
            
            while (startIndex < endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (nums[midIndex] > nums[endIndex])
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex;
                }
           }

            return startIndex;
        }
        public static int ProductSum(List<object> array)
        {
            return ProductSumHelper(array, 1);
        }

        public static int ProductSumHelper(List<object> array, int multiplier)
        {
            if (array.Count == 0)
            {
                return 0;
            }

            int sum = 0;

            foreach (var el in array)
            {
                if (el is IList<object>)
                {
                    sum += ProductSumHelper((List<object>)el, multiplier + 1);
                }
                else
                {
                    sum += (int)el;
                }
            }

            return sum * multiplier;
        }

        /// <summary>
        /// maximum-subarray
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int KadanesAlgorithm(int[] nums)
        {
            int maxSumEndingHere = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxSumEndingHere = Math.Max(nums[i], maxSumEndingHere + nums[i]);
                maxSum = Math.Max(maxSum, maxSumEndingHere);
            }
            return maxSum;
        }

        /// <summary>
        /// best-time-to-buy-and-sell-stock
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            int maxprofit = 0;
            int minValue = int.MaxValue;

            foreach (var price in prices)
            {
                if (price < minValue)
                {
                    minValue = price;
                }
                if (price - minValue > maxprofit)
                {
                    maxprofit = price - minValue;
                }
            }

            return maxprofit;
        }

        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            if (array.Length == 1)
            {
                return array[0];
            }

            int[] maxSums = new int[array.Length];
            maxSums[0] = array[0];
            maxSums[1] = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + array[i]);
            }
            return maxSums[array.Length - 1];
        }

        public static int[] BubbleSort(int[] array)
        {
            if (array.Length == 0)
            {
                return new int[] { };
            }

            bool isSorted = false;
            int counter = 0;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < array.Length - 1 - counter; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        isSorted = false;
                    }
                }
                counter++;
            }
            return array;
        }

        public static int[] InsertionSort(int[] array)
        {
            if (array.Length == 0)
            {
                return new int[] { };
            }

            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap(array, j, j - 1);
                    j -= 1;
                }

            }
            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            if (array.Length == 0)
            {
                return new int[] { };
            }

            int startIndex = 0;

            while (startIndex < array.Length - 1)
            {
                int smallestIndex = startIndex;
                for (int i = startIndex + 1; i < array.Length; i++)
                {
                    if (array[smallestIndex] > array[i])
                    {
                        smallestIndex = i;
                    }
                }

                Swap(array, smallestIndex, startIndex);
                startIndex++;
            }

            return array;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int index = 1;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[index] = nums[i + 1];
                    index++;
                }
            }

            return index;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;
            int total = m + n - 1;

            while (p1 >=0  && p2>=0)
            {
                nums1[total--] = nums1[p1] > nums2[p2] ? nums1[p1--] : nums2[p2--];
            }

            while (p2 >= 0)
            {
                nums1[total--] = nums2[p2--];
            }
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int index = 0;

            for (int i = 0; i < nums.Length ; i++)
            {
                if (nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            return index;
        }

        #region Sliding Window Problems

        public static int MinSubArrayLen(int s, int[] nums)
        {
            int minSumCount = int.MaxValue;
            int start = 0;
            int runningSum = 0;

            for (int i = 0 ; i < nums.Length; i++)
            {
                runningSum += nums[i];

                while (runningSum >= s)
                {
                    minSumCount = Math.Min(minSumCount, i + 1 - start);
                    runningSum -= nums[start++];
                }
            }

            return minSumCount == int.MaxValue ? 0 : minSumCount;
        }

        #endregion

        private static int[] Swap(int[] input, int start, int end)
        {
            int temp = input[start];
            input[start] = input[end];
            input[end] = temp;
            return input;
        }

        private static List<int> Swap(List<int> input, int start, int end)
        {
            int temp = input[start];
            input[start] = input[end];
            input[end] = temp;
            return input;
        }
    }
}

