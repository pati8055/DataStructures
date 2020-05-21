using System;
using System.Collections.Generic;
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

                return false;
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
    }
}
