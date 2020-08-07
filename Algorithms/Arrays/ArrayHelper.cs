using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Algorithms.Arrays
{
    public static class ArrayHelper
    {

        #region 2 Numbers sum

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

        public static int[] TwoSumSorted(int[] numbers, int target)
        {
            int[] result = new int[2] { -1, -1 };

            if (numbers == null || numbers.Length == 0)
            {
                return result;
            }

            int start = 0;
            int end = numbers.Length - 1;

            while (start < end)
            {
                int potentialTarget = numbers[start] + numbers[end];
                if (potentialTarget == target)
                {
                    return new int[] { start, end };
                }
                else if (potentialTarget < target)
                {
                    start++;
                }
                else if(potentialTarget > target)
                {
                    end--;
                }
            }

            return result;
        }
        #endregion

        public static int CountPrimes(int n)
        {
            bool[] primes = new bool[n];
            for (int i = 0; i < n; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i*i < primes.Length; i++)
            {
                for (int j = i; j*i < primes.Length; j++)
                {
                    primes[i * j] = false;
                }
            }

            int primecount = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    primecount++;
                }
            }
            return primecount;
        }


        //With out duplicates
        public static List<IList<int>> ThreeNumberSum(int[] nums, int targetSum)
        {
            Array.Sort(nums);
            var numberSum = new List<IList<int>>();           

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int currentSum = nums[i] + nums[left] + nums[right];

                        if (currentSum == targetSum)
                        {
                            numberSum.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left+1])
                            {
                                left++;
                            }
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }
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
            }

            return numberSum.ToList();
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

        public static int MySqrt(int x)
        {
            if (x < 2)
            {
                return x;
            }

            long start = 0;
            long end = x/2;

            while (start <= end)
            {
                long pivot = start + (end - start) / 2;
                long squaredValue = pivot * pivot;
                if (squaredValue == x)
                {
                    return (int)pivot;
                }
                else if(squaredValue > x)
                {
                    end = pivot-1;
                }
                else
                {
                    start = pivot+1;
                }
            }

            return (int)end;
        }

        public static double MyPow(double x, int n)
        {
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return MyPowHelper(x, N);
        }

        private static double MyPowHelper(double x, long n)
        {
            if (n == 0)
            {
                return 1.0;
            }
            double half = MyPowHelper(x, n / 2);
            if (n % 2 == 0)
            {
                return half * half;
            }
            else
            {
                return x * half * half;
            }
        }

        //Monotonic : Has to be Either Descending or Ascending
        public static bool IsMonotonic(int[] A)
        {
            bool isAscending = true;
            bool isDescending = true;

            for (int i = 0; i < A.Length-1; i++)
            {
                if (A[i] > A[i+1])
                {
                    isAscending = false;
                }

                if (A[i] < A[i+1])
                {
                    isDescending = false;
                }
            }
            return isAscending || isDescending;

        }

        public static int Compress(char[] chars)
        {
            if (chars == null || chars.Length == 0)
            {
                return 0;
            }

            int index = 0;
            int i = 0;

            while (i < chars.Length)
            {
                int j = i;
                while (j < chars.Length && chars[i] == chars[j])
                {
                    j++;
                }

                chars[index++] = chars[i]; //save charecter

                if (j - i > 1)
                {
                    string count = j - i + "";

                    foreach (char c in count) //Loop to account for double digits
                    {
                        chars[index++] = c;
                    }
                }

                i = j;
            }
            return index;
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
           

            int[] output = new int[length];

            output[0] = 1;

            for (int i = 1; i < length; i++)
            {
                output[i] = output[i - 1] * nums[i-1];
            }

            int sum = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                output[i] = sum * output[i];
                sum *= nums[i];
            }          

            return output;
        }

        public static int SubarraySum(int[] nums, int k)
        {
            int runningSum = 0;
            int sumCount = 0;
            Dictionary<int, int> sumMapper = new Dictionary<int, int>();
            sumMapper.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];

                if (sumMapper.ContainsKey(runningSum - k))
                {
                    //This is to account for same sum hapenning multiple times
                    sumCount += sumMapper[runningSum - k]; 
                }

                if (!sumMapper.ContainsKey(runningSum))
                {
                    sumMapper.Add(runningSum, 1);
                }
                else
                {
                    sumMapper[runningSum] = sumMapper[runningSum] + 1;
                }

            }

            return sumCount;
        }

        public static bool CheckSubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> sumMapper = new Dictionary<int, int>();
            sumMapper.Add(0, -1);

            int runningsum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                runningsum += nums[i];
                if (k !=0)
                {
                    runningsum %= k;
                }

                if (sumMapper.ContainsKey(runningsum))
                {
                    int prev = sumMapper[runningsum];

                    if (i - prev > 1 )
                    {
                        return true;
                    }
                }
                else
                {
                    sumMapper.Add(runningsum, i);
                }
            }

            return false;
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

        public static int MaxProfit2(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
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

        public static IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                {
                    result.Add(index + 1);
                }
                nums[index] *= -1; //Mark as Visisted
            }
            return result;
        }

        public static int MissingNumber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int length = nums.Length;

            int expected = (length * (length + 1)) / 2;
            int actualSum = 0;

            foreach (var num in nums)
            {
                actualSum += num;
            }
            return expected - actualSum;
        }

        public static int MissingNumberHashSet(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            HashSet<int> map = new HashSet<int>();

            foreach (var num in nums)
            {
                map.Add(num);
            }

            int expected = nums.Length + 1;

            for (int i = 0; i < expected; i++)
            {
                if (!map.Contains(i))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 1;
            }

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (!set.Contains(i))
                    return i;
            }

            return 1;
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            var result = new int[2];
            result[0] = FindStartingIndex(nums, target);
            result[1] = FindEndingIndex(nums, target);

            return result;
        }

        private static int FindStartingIndex(int[] nums, int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length -1 ;

            while (start <= end)
            {
                int mid = start + (end-start) / 2;
                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

                if (nums[mid] == target)
                {
                    index = mid;                  
                }
            }
            return index;
        }

        private static int FindEndingIndex(int[] nums, int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end-start) / 2;
                if (nums[mid] <= target)
                {
                    start = mid + 1;                    
                }
                else
                {
                    end = mid - 1;
                }

                if (nums[mid] == target)
                {
                    index = mid;                   
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

        public static int[][] Merge(int[][] intervals)
        {
            int length = intervals.Length;
            if (length <= 1)
                return intervals;

            int[] start = new int[length];
            int[] end = new int[length];
            for (int i = 0; i < length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }
            Array.Sort(start);
            Array.Sort(end);
            int startIndex = 0;
            int endIndex = 0;
            List<int[]> result = new List<int[]>();
            while (endIndex < length)
            {
                //as endIndex==length-1 is evaluated first, start[endIndex+1] will never hit out of index
                if (endIndex == length - 1 || start[endIndex + 1] > end[endIndex])
                {
                    result.Add(new int[] { start[startIndex], end[endIndex] });
                    startIndex = endIndex + 1;
                }
                endIndex++;
            }
            return result.ToArray();
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

        #region 2D Arrays

        public static int[][] Transpose(int[][] A)
        {
            if (A== null)
            {
                return new int[0][];
            }
            int rowLength = A.Length;
            int columnLength = A[0].Length;
            int[][] newMatrix = new int[columnLength][];

            for (int i = 0; i < columnLength; i++)
            {
                newMatrix[i] = new int[rowLength];
                for (int j = 0; j < rowLength; j++)
                {                  
                    newMatrix[i][j] = A[j][i];                  
                }
            }
            return newMatrix;
        }

        public static void Rotate(int[][] matrix)
        {
            int length = matrix.Length;            

            //Transpose
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            //swap
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length/2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][length -1 -j];
                    matrix[i][length - 1 - j] = temp;
                }
            }
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();

            if (matrix.Length == 0)
            {
                return result;
            }

            int rowLength = matrix.Length - 1;
            int columnLength = matrix[0].Length - 1;

            int rs = 0, re = rowLength;
            int cs = 0, ce = columnLength;

            while (rs <= re && cs <= ce)
            {
                //Traverse Right
                for (int i = cs; i <= ce; i++)
                {
                    result.Add(matrix[rs][i]);
                }
                rs++;
                //Traverse Down
                for (int i = rs; i <= re; i++)
                {
                    result.Add(matrix[i][ce]);
                }
                ce--;
                //Traverse left
                if (rs <= re)
                {
                    for (int i = ce; i>=cs; i--)
                    {
                        result.Add(matrix[re][i]);
                    }
                }
                re--;
                //TraverseRight
                if (cs <=  ce)
                {
                    for (int i = re; i >= rs; i--)
                    {
                        result.Add(matrix[i][cs]);
                    }
                }
                cs++;
            }

            return result;
        }

        public static int NumIslands(char[][] grid)
        {
            int numIslands = 0;

            if (grid == null || grid.Length == 0)
            {
                return numIslands;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIslands += NumIslandHelper(grid, i, j);
                    }                   
                }
            }

            return numIslands;
        }

        //DFS
        private static int NumIslandHelper(char[][] grid, int i, int j)
        {            
            //Boundaries check
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
            {
                return 0;
            }

            //Make Visited Isalnd's 0,so we don't want to revisit
            grid[i][j] = '0';

            //Traverse Up,Down,left,right
            NumIslandHelper(grid, i - 1, j);
            NumIslandHelper(grid, i + 1, j);
            NumIslandHelper(grid, i, j+1);
            NumIslandHelper(grid, i, j-1);

            return 1; //Account for current Island
        }

        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor)
            {
                return image;
            }

            FloodFillHelper(image, sr, sc, image[sr][sc], newColor);

            return image;
        }

        //DFS
        private static void FloodFillHelper(int[][] image, int i, int j, int currentColor, int newColor)
        {
            if (i < 0 || i >= image.Length || j < 0 || j >= image[i].Length || image[i][j] != currentColor)
            {
                return;
            }

            image[i][j] = newColor;
            FloodFillHelper(image, i - 1, j, currentColor, newColor);
            FloodFillHelper(image, i + 1, j, currentColor, newColor);
            FloodFillHelper(image, i , j - 1, currentColor, newColor);
            FloodFillHelper(image, i , j + 1, currentColor, newColor);

        }

        public static void WallsAndGates(int[][] rooms)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                for (int j = 0; j < rooms[i].Length; j++)
                {
                    if (rooms[i][j] == 0) //Gate in this example
                    {
                        WallsAndGatesHelper(rooms, i, j, 0);
                    }
                }
            }
        }

        //DFS
        private static void WallsAndGatesHelper (int[][] image, int i, int j, int count)
        {

            if (i < 0 || i >= image.Length || j < 0 || j >= image[i].Length|| image[i][j] < count)
            {
                return;
            }

            image[i][j] = count;
            WallsAndGatesHelper(image, i - 1, j, count + 1);
            WallsAndGatesHelper(image, i + 1, j, count + 1);
            WallsAndGatesHelper(image, i, j-1, count + 1);
            WallsAndGatesHelper(image, i, j + 1, count + 1);
        }

        //word search
        public static bool Exist(char[][] board, string word)
        {
            if (board== null || board.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0] && WordSearchHelper(board,i, j,0,word))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private static bool WordSearchHelper(char[][] board,int i, int j,int count,string word)
        {
            if (count == word.Length)
            {
                return true;
            }

            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || board[i][j] != word[count])
            {
                return false;
            }

            char temp = board[i][j];
            board[i][j] = ' ';

            bool isFound =    WordSearchHelper(board, i + 1, j, count + 1, word) ||
                              WordSearchHelper(board, i - 1, j, count + 1, word) ||                            
                            WordSearchHelper(board, i, j-1, count + 1, word) ||
                            WordSearchHelper(board, i, j+1, count + 1, word);

            board[i][j] = temp;
            return isFound;
        }

        //BFS
        public static int OrangesRotting(int[][] grid)
        {
            HashSet<string> fresh = new HashSet<string>();
            HashSet<string> rotten = new HashSet<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        fresh.Add(""+i + j);
                    }
                    else if (grid[i][j] == 2)
                    {
                        rotten.Add("" + i + j);
                    }
                }
            }

            int minutes = 0;
            int[][] directions = new int[4][];
            directions[0] = new int[] { -1, 0 };
            directions[1] = new int[] { 0, 1 };
            directions[2] = new int[] { 1, 0 };
            directions[3] = new int[] { 0, -1 };

            while (fresh.Count > 0)
            {
                HashSet<string> infected = new HashSet<string>();

                foreach (var s in rotten)
                {
                    int i = s[0] - '0';
                    int j = s[1] - '0';

                    foreach (var direction in directions)
                    {
                        int nextI = i + direction[0];
                        int nextJ = j + direction[1];

                        string target = "" + nextI + nextJ;

                        if (fresh.Contains(target))
                        {
                            fresh.Remove(target);
                            infected.Add(target);
                        }
                    }                              
                }

                if (infected.Count == 0)
                {
                    return -1;
                }

                rotten = infected;
                minutes++;
            }

            return minutes;
        }

        #endregion

        public static int MaxArea(int[] height)
        {
            int maxarea = 0;
            int left = 0; 
            int right = height.Length - 1;
            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                maxarea = Math.Max(maxarea, area);
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }
            return maxarea;
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

        //Greedy Approach
        public static bool CanJump(int[] nums)
        {
            if (nums.Length == 0)
            {
                return false;
            }

            int lastKnownPosition = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= lastKnownPosition)
                {
                    lastKnownPosition = i;
                }
            }
            return lastKnownPosition == 0;
        }

        #region Back Tracking      
        //https://leetcode.com/problems/subsets/discuss/27281/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            generateParanthesisHelper(result, string.Empty, 0, 0, n);
            return result;
        }
        private static void generateParanthesisHelper(List<string> result,
                                         string currentString,int open,int close,int max)
        {
            if (currentString.Length == max * 2)
            {
                result.Add(currentString);
                return;
            }

            if (open < max)
            {
                generateParanthesisHelper(result, currentString + "(", open + 1, close, max);
            }

            if (close < open)
            {
                generateParanthesisHelper(result, currentString + ")", open , close + 1, max);

            }

        }


        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            SubsetHelper(list, new List<int>(), nums, 0);
            return list;
        }
        private static void SubsetHelper(List<IList<int>> list, List<int> tempList, int[] nums, int start)
        {
           list.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                SubsetHelper(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }

        public static List<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            SubsetsWithDupHelper(list, new List<int>(), nums, 0);
            return list;
        }
        private static void SubsetsWithDupHelper(List<IList<int>> list, List<int> tempList, int[] nums, int index)
        {
            list.Add(new List<int>(tempList));
            for (int i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1]) continue; //Avoid Duplication

                tempList.Add(nums[i]);
                SubsetsWithDupHelper(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);

            }
        }

        public static List<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            PermuteHelper(list, new List<int>(), nums);
            return list;
        }
        private static void PermuteHelper(List<IList<int>> result,List<int> current,int[] nums)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (current.Contains(nums[i]))
                {
                    continue;
                }
                current.Add(nums[i]);
                PermuteHelper(result, current, nums);
                current.RemoveAt(current.Count - 1);
            }
        }


        public static List<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSumHelper(list, new List<int>(), candidates, target, 0);
            return list;
        }
        private static void CombinationSumHelper(List<IList<int>> result, List<int> current, int[] candidates, int target, int index)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }
            if (target < 0)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {              
                current.Add(candidates[i]);
                CombinationSumHelper(result, current, candidates, target - candidates[i], i);// i  because we can reuse same elements
                current.RemoveAt(current.Count - 1);
            }
        }


        public static List<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum2Helper(list, new List<int>(), candidates, target,0);
            return list;
        }
        private static void CombinationSum2Helper(List<IList<int>> result, List<int> current, int[] candidates, int target, int index)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }
            if (target < 0)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i - 1]) //No Duplicates
                {
                    continue;
                }
                current.Add(candidates[i]);
                CombinationSum2Helper(result, current, candidates, target - candidates[i], i + 1);// i + 1 because we cann't reuse same elements
                current.RemoveAt(current.Count - 1);
            }

        }

        #endregion

        #region Dynamic Programming

        public static int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return Math.Max(nums[0],nums[1]);
            }

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0],nums[1]);

            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }
        public static int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
                dp[i] = new int[n];

            for (int i = 0; i < m; i++)//first column
                dp[i][0] = 1;

            for (int i = 0; i < n; i++) //First row
                dp[0][i] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }

        public static int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int[][] dp = new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[i].Length];
            }

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] += grid[i][j];
                    if (i > 0 && j > 0)
                    {
                        dp[i][j] += Math.Min(dp[i - 1][j], dp[i][j - 1]);
                    }
                    else if (i > 0)
                    {
                        dp[i][j] += dp[i - 1][j];
                    }
                    else if (j > 0)
                    {
                        dp[i][j] += dp[i][j - 1];
                    }
                }
            }
            return dp[dp.Length -1][dp[0].Length-1];
        }
        //Like Fibinocci
        public static int ClimbStairs(int n)
        {

            if (n == 1)
            {
                return 1;
            }

            int[] dp = new int[n + 1];

            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        public static int NumDecodings(string s)
        {
            int length = s.Length;
            int[] dp = new int[length + 1];
            dp[0] = 1;
            dp[1] = s[0] == '0' ? 0 : 1;

            for (int i = 2; i <= length; i++)
            {
                int oneDigit = int.Parse(s.Substring(i-1 , 1));
                int twoDigit = int.Parse(s.Substring(i-2, 2));

                if (oneDigit >= 1 && oneDigit <= 9)
                {
                    dp[i] = dp[i] + dp[i - 1];
                }

                if (twoDigit >=10 && twoDigit <=26)
                {
                    dp[i] = dp[i] + dp[i - 2];
                }
            }
            return dp[length];
        }

        //Number of ways to make Change
        public static int Change(int amount, int[] coins)
        {
            int[] ways = new int[amount + 1];
            ways[0] = 1; //Nuber of ways to make 0 change is 1(i..e, don't do anything)
           
            foreach (int coin in coins)
            {
                for (int targetAmount = 1; targetAmount < amount + 1; targetAmount++)
                {
                    if (coin <= targetAmount)
                    {
                        ways[targetAmount] = ways[targetAmount] + ways[targetAmount - coin];
                    }
                }
            }

            return ways[amount];
        }

        //Minimum Change
        public static int CoinChange(int[] coins, int amount)
        {
            int[] result = new int[amount + 1];
            Array.Fill(result, int.MaxValue);

            result[0] = 0; //Minimum change to makeup 0
            foreach (var coin in coins)
            {
                for (int targetAmount = 1; targetAmount < amount + 1; targetAmount++)
                {
                    if (coin <= targetAmount)
                    {
                       int minValue =  result[targetAmount - coin] == int.MaxValue ? result[targetAmount - coin] : 1 + result[targetAmount - coin];
                        result[targetAmount] = Math.Min(result[targetAmount], minValue);
                    }
                }
            }

            return result[amount] == int.MaxValue ? -1 : result[amount];
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

