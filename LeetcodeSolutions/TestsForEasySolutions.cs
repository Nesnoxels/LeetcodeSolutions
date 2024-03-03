namespace LeetcodeSolutions
{
    public class TestsForEasySolutions
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(5, 8)]
        public void Task70(int n, int fib) =>
            Assert.Equal(fib, EasySolutions.ClimbStairs(n));

        [Theory]
        [InlineData(4, 2)]
        [InlineData(15, 3)]
        public void Task69(int x, int sqrt) =>
            Assert.Equal(sqrt, EasySolutions.MySqrt(x));

        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        public void Task67(string a, string b, string sum) =>
            Assert.Equal(sum, EasySolutions.AddBinary(a, b));

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
        [InlineData(new int[] { 2, 9, 9 }, new int[] { 3, 0, 0 })]
        [InlineData(new int[] { 9, 9 }, new int[] { 1, 0, 0 })]
        public void Task66(int[] digits, int[] res) =>
            Assert.Equal(res, EasySolutions.PlusOne(digits));

        [Theory]
        [InlineData("Hello World", 5)]
        [InlineData("   fly me   to   the moon  ", 4)]
        public void Task58(string s, int count) =>
            Assert.Equal(count, EasySolutions.LengthOfLastWord(s));

        [Theory]
        [InlineData(new int[] { 1, 3, 5, 6 }, 5, 2)]
        [InlineData(new int[] { 1, 2, 4, 5, 6 }, 2, 1)]
        [InlineData(new int[] { 1, 3, 5 }, 2, 1)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 7, 4)]
        public void Task35(int[] nums, int target, int index) =>
            Assert.Equal(index, EasySolutions.SearchInsert(nums, target));

        [Theory]
        [InlineData("sadbutsad", "sad", 0)]
        [InlineData("leetcode", "leeto", -1)]
        public void Task28(string haystack, string needle, int index) =>
            Assert.Equal(index, EasySolutions.StrStr(haystack, needle));

        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
        public void Task27(int[] nums, int val, int count) =>
            Assert.Equal(count, EasySolutions.RemoveElement(nums, val));

        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, 2)]
        [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        public void Task26(int[] nums, int count) =>
            Assert.Equal(count, EasySolutions.RemoveDuplicates(nums));

        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(null, null, null)]
        public void Task21(int[] values1, int[] values2, int[] mergedValues) =>
            Assert.Equal(mergedValues == null ? null : new(ref mergedValues),
                EasySolutions.MergeTwoLists(values1 == null ? null : new(ref values1),
                                            values2 == null ? null : new(ref values2)));

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("{(})", false)]
        public void Task20(string s, bool valid) =>
            Assert.Equal(valid, EasySolutions.IsValid(s));

        [Theory]
        [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
        [InlineData(new string[] { "dog", "racecar", "car" }, "")]
        public void Task14(string[] strs, string prefix) =>
            Assert.Equal(prefix, EasySolutions.LongestCommonPrefix(strs));

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Task13(string s, int toInt) =>
            Assert.Equal(toInt, EasySolutions.RomanToInt(s));

        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(1441, true)]
        public void Task9(int x, bool exp) =>
            Assert.Equal(exp, EasySolutions.IsPalindrome(x));

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, 0, 1)]
        [InlineData(new int[] { 3, 2, 4 }, 6, 1, 2)]
        [InlineData(new int[] { 3, 3 }, 6, 0, 1)]
        public void Task1(int[] nums, int target, int index1, int index2) =>
            Assert.Equal([index1, index2], EasySolutions.TwoSum(nums, target));
    }
}