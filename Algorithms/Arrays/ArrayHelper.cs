using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

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


    }
}

