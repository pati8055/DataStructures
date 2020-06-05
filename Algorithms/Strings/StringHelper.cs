﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Algorithms.Strings
{
    public static class StringHelper
    {
        public static bool BuddyStrings(string A, string B)
        {

            if(A.Length != B.Length)
            {
                return false;
            }

            if(A.Equals(B))
            {
                HashSet<char> set = new HashSet<char>();

                foreach (char c in A)
                {
                    if (!set.Contains(c))
                    {
                        set.Add(c);
                    }
                }

                if( set.Count < A.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            List<int> diffs = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    diffs.Add(i);
                }
            }

            if (diffs.Count == 2 && 
                A[diffs[0]] == B[diffs[1]] &&
                 A[diffs[1]] == B[diffs[0]])
            {
                return true;
            }

            return false;
        }

        public static bool IsPalindrome(string str)
        {
            bool isPalindrome = true;

            int leftIndex = 0;
            int rightIndex = str.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (str[leftIndex] != str[rightIndex])
                {
                    isPalindrome = false;
                    break;
                }

                leftIndex++;
                rightIndex--;

            }

            return isPalindrome;
        }

        public static bool BalancedBrackets(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            bool isBalanced = true;
            string startBrackets = "[{(";
            Dictionary<char, char> matchingBrackets = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
            Stack<char> stack = new Stack<char>();

            foreach (var item in str.ToCharArray())
            {
                if (startBrackets.Contains(item))
                {
                    stack.Push(item);                    
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char popedItem = stack.Pop();
                    if (matchingBrackets[popedItem] != item)
                    {
                        return false;                      
                    }                
                }               

            }

            if (stack.Count != 0)
            {
               return  false;
            }
            return isBalanced;
        }
        public static List<List<string>> GroupAnagrams(List<string> words)
        {
            if (words == null  || !words.Any())
            {
                return new List<List<string>>();
            }
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var charArray = word.ToCharArray();
                Array.Sort(charArray);
                string sortedString = new string(charArray);

                if (anagrams.ContainsKey(sortedString))
                {
                    anagrams[sortedString].Add(word);
                }
                else
                {
                    anagrams.Add(sortedString, new List<string> { word });
                }
            }

           return (anagrams.Select(anagram => anagram.Value)).ToList();
        }

        public static string CaesarCypherEncryptor(string str, int key)
        {
            int newKey = key % 26;
            var charArray = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = GetNewLetter(str[i], newKey);
            }

            return new string(charArray);
        }

        /// <summary>
        /// Find susbtring Index in MainString AKA.. Strstr
        /// </summary>
        /// <param name="hayStack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public static int FindSubstringIndex(string hayStack, string needle)
        {
            if (string.IsNullOrWhiteSpace(hayStack))
            {
                return -1;
            }

            for (int i = 0; i < hayStack.Length; i++)
            {
                if ( i + needle.Length > hayStack.Length)
                {
                    break;
                }

                for (int j = 0; j < needle.Length; j++)
                {
                    if (hayStack[i + j] != needle[j])
                    {
                        break;
                    }

                    if (j == needle.Length - 1)
                    {
                        return i;
                    }
                }

            }


            return -1;
        }

        public static string FrequencySort(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            Dictionary<char,int> charCountMap = new Dictionary<char, int>();

            foreach (var letter in s.ToCharArray())
            {
                if (charCountMap.ContainsKey(letter))
                {
                    charCountMap[letter] += 1;
                }
                else
                {
                    charCountMap.Add(letter,1);
                }
            }

            var ordered = charCountMap.OrderByDescending(x => x.Value);

            var result = new StringBuilder();

            foreach (var letter in ordered)
            {
                for (int i = 0; i < letter.Value; i++)
                {
                    result.Append(letter.Key);
                }
            }

            return result.ToString();
        }

        public static int NumJewelsInStones(string J, string S)
        {
            if(string.IsNullOrEmpty(J) || string.IsNullOrWhiteSpace(S))
            {
                return -1;
            }

            HashSet<char> jewelSet = new HashSet<char>();
            foreach (var letter in J.ToCharArray())
            {
                jewelSet.Add(letter);
            }

            int resultSum = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (jewelSet.Contains(S[i]))
                {
                    resultSum ++;
                }               
            }

            return resultSum;
        }

        public static int LengthOfLongestSubstringLength(string s)
        {
            int start = 0;
            int end = 0;
            int maxLength = 0;

            Dictionary<int,int> charMap = new Dictionary<int, int>();

            while (end < s.Length)
            {
                if (!charMap.ContainsKey(s[end]))
                {
                    charMap.Add(s[end], end);
                    end++;
                    maxLength = Math.Max(maxLength, charMap.Count);
                }
                else
                {
                    charMap.Remove(s[start]);
                    start++;
                }
                
            }

            return maxLength;
        }

        public static string LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int end = 0;
            int[] longest = { 0, 1 };

            Dictionary<int, int> charMap = new Dictionary<int, int>();

            while (end < s.Length)
            {
                if (!charMap.ContainsKey(s[end]))
                {
                    charMap.Add(s[end], end);
                    end++;
                    if (end - start > longest[1] - longest[0])
                    {
                        longest = new int[] { start, end };
                    }
                }
                else
                {
                    charMap.Remove(s[start]);
                    start++;
                }

            }

            return s.Substring(longest[0], longest[1] - longest[0]);
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            int[] currentLongest = new int[] { 0, 1 };

            for (int i = 1; i < s.Length; i++)
            {
                int[] odd = GetLongestPlaindrome(s, i - 1, i+1);
                int[] even = GetLongestPlaindrome(s, i - 1, i);
                int[] longest = odd[1] - odd[0] > even[1] - even[0] ? odd : even;
                currentLongest = currentLongest[1] - currentLongest[0] > longest[1] - longest[0] ? currentLongest : longest;

            }

            return s.Substring(currentLongest[0], currentLongest[1]- currentLongest[0]);
        }

        private static int[] GetLongestPlaindrome(string s, int start, int end)
        {
            while (start >=0 && end < s.Length)
            {
                if (s[start] != s[end])
                {
                    break;
                }

                start--;
                end++;
            }

            return new int[] {start+1 , end };
        }
        public static bool UniqueStringMapping(string s1,string s2)
        {
            bool isUniqueChar = true;

            if (string.IsNullOrEmpty(s1) || string.IsNullOrWhiteSpace(s2))
            {
                return false;
            }

            int counter = 0;
            Dictionary<char, List<char>> stringMap = new Dictionary<char, List<char>>();

            while (counter < s1.Length && counter < s2.Length)
            {               
                if (!stringMap.ContainsKey(s1[counter]))
                {
                    stringMap.Add(s1[counter], new List<char> { s2[counter] });
                }
                else
                {
                    var mappingList = stringMap[s1[counter]];

                    if (!mappingList.Contains(s2[counter]))
                    {
                        return false;
                    }
                }
                counter++;
            }
            return isUniqueChar;
        }

        /// <summary>
        /// a => 97
        /// z => 122
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static char GetNewLetter (char letter, int key)
        {
            int newLetterCode = letter + key;
            return newLetterCode <= 122 ? (char)newLetterCode : (char) (96 + newLetterCode % 122);
        }
    }
}
