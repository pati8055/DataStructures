using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms.Arrays
{
    public static class ArrayHelper
    {
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;

            while(left < right)
            {
                int currentSum = array[left] + array[right];

                if(currentSum == targetSum)
                {
                    return new int[] { array[left], array[right] };
                }
                else if ( currentSum > targetSum)
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
            return isNegativeNumber ? (int) (-1 * reverseNumber) :(int)reverseNumber;
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
            // For example when the input is 12321, at the end of the while loop we get x = 12, revertedNumber = 123,
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
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
                else if( secondMax == null || num > secondMax)
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
                if (leftSum == totalSum - nums[i]- leftSum)
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
                else if(secondnum < firstnum)
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
            int right = array.Length -1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                int potentialmatch = array[middle];
                if (potentialmatch > target)
                {
                    right = middle - 1;
                }
                else if (potentialmatch < target)
                {
                    left = middle + 1;
                }
                else if (potentialmatch == target)
                {
                    return middle;
                }
            }          

            return -1;
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
                    if (array[i] > array [i+1])
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
                while (j > 0 && array[j] < array[j-1])
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
                return new int[] {};
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
        private static int[] Swap ( int[] input, int start, int end)
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

