using System;
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

            return stack.Count == 0;
        }
        public static IList<IList<string>> GroupAnagrams(List<string> words)
        {
            if (words == null  || !words.Any())
            {
                return new List<IList<string>>();
            }
            var anagrams = new Dictionary<string, IList<string>>();

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
        public static int FindSubstringIndex(string haystack, string needle)
        {

            int hl = haystack.Length;
            int nl = needle.Length;

            if (hl < nl) return -1;
            if (nl == 0) return 0;

            for (int i = 0; i <= hl - nl; i++)
            {
                if (haystack.Substring(i, nl).Equals(needle))
                    return i;
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

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return string.Empty;
            }

            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }
            }
            return prefix;
        }

        //BFS
        public static IList<string> LetterCombinations(string digits)
        {
            Queue<string> result = new Queue<string>();
            if (digits.Length == 0)
            {
                return result.ToList();
            }

            result.Enqueue(string.Empty);

            Dictionary<string, string> phone = new Dictionary<string, string>() {
                { "2", "abc" },
            {"3", "def"},
            {"4", "ghi"},
            {"5", "jkl"},
            {"6", "mno" },
            {"7", "pqrs" },
            {"8", "tuv" },
            { "9", "wxyz" } };

            for (int i = 0; i < digits.Length; i++)
            {
                string permutation = phone.GetValueOrDefault(digits[i].ToString());
                while (result.Peek().Length == i)
                {
                    string removedValue = result.Dequeue();
                    foreach (char c in permutation.ToArray())
                    {
                        result.Enqueue(removedValue + c);
                    }

                }
            }

            return result.ToList();
            
        }

        public static int LongestValidParentheses(String s)
        {
            int maxLength = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }
            return maxLength;
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            //Build a int Array - for Mapping
            int[] charMap = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                charMap[order[i] - 'a'] = i;
            }

            for (int i = 1; i < words.Length; i++)
            {
                if (AlienSortedHelper(words[i - 1], words[i], charMap) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int AlienSortedHelper(string word1, string word2,int[] charMap)
        {
            int i = 0;
            int j = 0;
            int compareValue = 0;

            while (i < word1.Length && j < word2.Length && compareValue == 0)
            {
                compareValue = charMap[word1[i] - 'a'] - charMap[word2[i] - 'a'];
                i++;
                j++;

            }

            if (compareValue == 0)
            {
                return word1.Length - word2.Length;
            }

            return compareValue;

        }


        public static string AddStrings(string num1, string num2)
        {
            StringBuilder result = new StringBuilder(); 

            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;
            int carry = 0;            

            while (p1 >= 0 || p2 >= 0)
            {
                int sum = carry;
                if (p1 >= 0)
                {
                    sum += num1[p1--]-'0';
                }

                if (p2 >= 0)
                {
                    sum += num2[p2--]-'0';
                }

                result.Append(sum % 10);
                carry = sum / 10;
            }

            if (carry !=0)
            {
                result.Append(carry);
            }

            return new string(result.ToString().Reverse().ToArray());
        }

        public static bool IsPalindrome2(string s)
        {
            s = s.ToLower();

            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                while (start < end && !char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }

                while (start < end && !char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }

                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }

            return true;
        }

        public static bool ValidPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return IsPalindromeHelper(s, start + 1, end) || IsPalindromeHelper(s, start, end - 1);
                }
                start++;
                end--;
            }
            return true;
        }

        public static bool IsPalindromeHelper(string str, int i, int j)
        {
            while (i < j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
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
