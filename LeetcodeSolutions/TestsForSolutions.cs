using LeetcodeSolutions.ExtensionClassesForSolutions;

namespace LeetcodeSolutions
{
    public class TestsForSolutions
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(null, null, null)]
        public void Task21(int[] values1, int[] values2, int[] mergedValues)
        {
            ListNode list1 = new(ref values1);
            ListNode list2 = new(ref values2);
            ListNode mergedList = new(ref mergedValues);

            var result = Solutions.Instance.MergeTwoLists(list1, list2);

            Assert.Equal(result, mergedList);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("{(})", false)]
        public void Task20(string s, bool valid)
        {
            var result = Solutions.Instance.IsValid(s);

            Assert.Equal(valid, result);
        }

        [Theory]
        [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
        [InlineData(new string[] { "dog", "racecar", "car" }, "")]
        public void Task14(string[] strs, string prefix)
        {
            var result = Solutions.Instance.LongestCommonPrefix(strs);

            Assert.Equal(prefix, result);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Task13(string s, int toInt)
        {
            var result = Solutions.Instance.RomanToInt(s);

            Assert.Equal(toInt, result);
        }

        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(1441, true)]
        public void Task9(int x, bool exp)
        {
            var result = Solutions.Instance.IsPalindrome(x);

            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, 0, 1)]
        [InlineData(new int[] { 3, 2, 4 }, 6, 1, 2)]
        [InlineData(new int[] { 3, 3 }, 6, 0, 1)]
        public void Task1(int[] nums, int target, int index1, int index2)
        {
            var result = Solutions.Instance.TwoSum(nums, target);

            Assert.Equal([index1, index2], result);
        }
    }
}