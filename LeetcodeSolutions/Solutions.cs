using LeetcodeSolutions.ExtensionClassesForSolutions;
using System;
using System.Collections.Generic;

namespace LeetcodeSolutions
{
    public class Solutions
    {
        public static Solutions Instance { get; private set; } = new();

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;

            if (list2 == null) return list1;

            ListNode thisVal, result;

            if (list1.val <= list2.val)
            {
                thisVal = result = list1;
                list1 = list1.next;
            }
            else
            {
                thisVal = result = list2;
                list2 = list2.next;
            }

            while (true)
            {
                if (list2 == null)
                {
                    thisVal.next = list1;
                    break;
                }
                else if (list1 == null)
                {
                    thisVal.next = list2;
                    break;
                }
                else if (list1.val <= list2.val)
                {
                    thisVal.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    thisVal.next = list2;
                    list2 = list2.next;
                }

                thisVal = thisVal.next;
            }

            return result;
        }

        public bool IsValid(string s)
        {
            var brackets = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            var awaiter = new Stack<char>();

            foreach (char c in s)
                if (c == '(' || c == '[' || c == '{')
                    awaiter.Push(brackets[c]);
                else if (awaiter.Count == 0 || c != awaiter.Pop())
                    return false;

            if (awaiter.Count != 0)
                return false;

            return true;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
                for (int j = 0; j < prefix.Length; j++)
                    if (j == strs[i].Length || prefix[j] != strs[i][j])
                    {
                        prefix = prefix[..j];

                        if (prefix.Length == 0)
                            return "";

                        break;
                    }

            return prefix;
        }

        public int RomanToInt(string s)
        {
            var romConst = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },

            };
            int result = 0;

            for (int i = 0; i < s.Length - 1; i++)
                if (romConst[s[i]] < romConst[s[i + 1]])
                    result -= romConst[s[i]];
                else
                    result += romConst[s[i]];

            return result + romConst[s[^1]];
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;

            var len = (int)MathF.Log10(x) + 1;
            int a = 1;
            int b = (int)MathF.Pow(10, len - 1);

            for (int i = 0; i < len / 2; i++)
            {
                if (x / a % 10 != x / b % 10)
                    return false;

                a *= 10;
                b /= 10;
            }

            return true;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var proofNums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (proofNums.TryGetValue(target - nums[i], out int index))
                    return [index, i];

                proofNums.TryAdd(nums[i], i);
            }

            return default;
        }
    }
}
