using System.Linq;

namespace LeetcodeSolutions;

public class TestsForEasySolutions
{
    [Theory]
    [InlineData(new object[] { 5, 4, 8, 11, null!, 13, 4, 7, 2, null!, null!, null!, 1 }, 22, true)]
    [InlineData(new object[] { 1, 2, 3 }, 5, false)]
    public void Task112(object[] root, int targetSum, bool has) =>
        Assert.Equal(has, EasySolutions.HasPathSum(root == null ? null! : new(GetTreeArray(root)), targetSum));

    [Theory]
    [InlineData(new object[] { 3, 9, 20, null!, null!, 15, 7 }, 2)]
    [InlineData(new object[] { 2, null!, 3, null!, 4, null!, 5, null!, 6 }, 5)]
    public void Task111(object[] root, int min) =>
        Assert.Equal(min, EasySolutions.MinDepth(root == null ? null! : new(GetTreeArray(root))));

    [Theory]
    [InlineData(new object[] { 3, 9, 20, null!, null!, 15, 7 }, true)]
    [InlineData(new object[] { 1, 2, 2, 3, 3, null!, null!, 4, 4 }, false)]
    [InlineData(new object[] { 1, 2, 2, 3, null!, null!, 3, 4, null!, null!, 4 }, false)]
    [InlineData(new object[] { 1, 2, 3, 4, 5, 6, null!, 8 }, true)]
    public void Task110(object[] root, bool balance) =>
        Assert.Equal(balance, EasySolutions.IsBalanced(root == null ? null! : new(GetTreeArray(root))));

    [Theory]
    [InlineData(new int[] { -10, -3, 0, 5, 9 }, new object[] { 0, -3, 9, -10, null!, 5 })]
    public void Task108(int[] nums, object[] BST) =>
        Assert.Equal(new(GetTreeArray(BST)), EasySolutions.SortedArrayToBST(nums));

    [Theory]
    [InlineData(new object[] { 3, 9, 20, null!, null!, 15, 7 }, 3)]
    [InlineData(new object[] { 1, null!, 2 }, 2)]
    public void Task104(object[] root, int depth) =>
        Assert.Equal(depth, EasySolutions.MaxDepth(root == null ? null! : new(GetTreeArray(root))));

    [Theory]
    [InlineData(new object[] { 1, 2, 2, 3, 4, 4, 3 }, true)]
    [InlineData(new object[] { 1, 2, 2, null!, 3, null!, 3 }, false)]
    public void Task101(object[] root, bool symmetric) =>
        Assert.Equal(symmetric, EasySolutions.IsSymmetric(root == null ? null! : new(GetTreeArray(root))));

    [Theory]
    [InlineData(new object[] { 1, 2, 3 }, new object[] { 1, 2, 3 }, true)]
    [InlineData(new object[] { 1, 2 }, new object[] { 1, null!, 2 }, false)]
    [InlineData(new object[] { 1, 1, 2 }, new object[] { 1, 2, 1 }, false)]
    public void Task100(object[] p, object[] q, bool @is) =>
        Assert.Equal(@is, EasySolutions.IsSameTree(
            p == null ? null! : new(GetTreeArray(p)),
            q == null ? null! : new(GetTreeArray(q))));

    [Theory]
    [InlineData(new object[] { 1, null!, 2, 3 }, new int[] { 1, 3, 2 })]
    [InlineData(null, new int[0])]
    [InlineData(new object[] { 1 }, new int[] { 1 })]
    public void Task94(object[] root, int[] traversal) =>
        Assert.Equal(traversal, EasySolutions.InorderTraversal(root == null ? null! : new(GetTreeArray(root))));

    private static int?[] GetTreeArray(object[] objects) =>
        objects.Cast<int?>().ToArray();

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
    public void Task88(int[] nums1, int m, int[] nums2, int n, int[] merged)
    {
        EasySolutions.Merge(nums1, m, nums2, n);

        Assert.Equal(merged, nums1);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 1, 2, 3, 3, 3 }, new int[] { 1, 2, 3 })]
    [InlineData(null, null)]
    public void Task83(int[] head, int[] deleted) =>
        Assert.Equal(deleted == null ? null : new(ref deleted),
            EasySolutions.DeleteDuplicates(head == null ? null! : new(ref head)));

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
            EasySolutions.MergeTwoLists(values1 == null ? null! : new(ref values1),
                                        values2 == null ? null! : new(ref values2)));

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