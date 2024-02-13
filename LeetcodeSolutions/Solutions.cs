using System;
using System.Collections.Generic;

namespace LeetcodeSolutions
{
    public class Solutions
    {
        public static Solutions Instance { get; private set; } = new();

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
