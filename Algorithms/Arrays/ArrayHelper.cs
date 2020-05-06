using System;
using System.Collections.Generic;
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
    }
}
