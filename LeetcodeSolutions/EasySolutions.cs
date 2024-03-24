using LeetcodeSolutions.ExtensionClassesForSolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolutions;

public class EasySolutions
{
    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;

        if (root.left == null && root.right == null)
            return targetSum == root.val;

        if (root.left == null)
            if (root.right.left != null || root.right.right != null)
                return HasPathSum(root.right, targetSum - root.val);
            else return targetSum == root.val + root.right.val;

        if (root.right == null)
            if (root.left.left != null || root.left.right != null)
                return HasPathSum(root.left, targetSum - root.val);
            else return targetSum == root.val + root.left.val;

        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }

    public static int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        if (root.left == null && root.right == null)
            return 1;

        if (root.left == null)
            if (root.right.left != null || root.right.right != null)
                return 1 + MinDepth(root.right);
            else return 2;

        if (root.right == null)
            if (root.left.left != null || root.left.right != null)
                return 1 + MinDepth(root.left);
            else return 2;

        return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));

        #region it's bad
        //if (root == null)
        //    return 0;

        //static int GetMin(TreeNode tree, int depth = 0)
        //{
        //    int left = tree.left == null ? int.MaxValue :
        //        tree.left.left != null || tree.left.right != null ?
        //        GetMin(tree.left, depth + 1) : depth + 2,

        //        right = tree.right == null ? int.MaxValue :
        //        tree.right.left != null || tree.right.right != null ?
        //        GetMin(tree.right, depth + 1) : depth + 2;

        //    return Math.Min(left, right);
        //}

        //var result = GetMin(root);
        //return result == int.MaxValue ? 1 : result;
        #endregion
    }

    public static bool IsBalanced(TreeNode root)
    {
        if (root == null)
            return true;

        static int GetIsBalanced(TreeNode tree, int iter = 0)
        {
            int left = tree.left == null ? iter + 1 :
                tree.left.left != null || tree.left.right != null ?
                GetIsBalanced(tree.left, iter + 1) : iter + 2,

                right = tree.right == null ? iter + 1 :
                tree.right.left != null || tree.right.right != null ?
                GetIsBalanced(tree.right, iter + 1) : iter + 2;

            if (Math.Abs(left - right) >= 2)
                return -1;

            return Math.Max(left, right);
        }

        return GetIsBalanced(root) != -1;
    }

    public static TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return null!;

        TreeNode GetTree(int left, int right)
        {
            if (left == right)
                return new(nums[left]);

            int mid = (left + right + 1) / 2;

            return new(nums[mid],
                left > mid - 1 ? null : GetTree(left, mid - 1),
                mid + 1 > right ? null : GetTree(mid + 1, right));
        }

        return GetTree(0, nums.Length - 1);
    }

    public static int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        static int Depthing(TreeNode root, int maxDepth = 1)
        {
            if (root.left == null && root.right == null)
                return maxDepth;

            if (root.left == null)
                return Depthing(root.right!, maxDepth + 1);

            if (root.right == null)
                return Depthing(root.left, maxDepth + 1);

            return Math.Max(Depthing(root.left, maxDepth + 1), Depthing(root.right, maxDepth + 1));
        }

        return Depthing(root);
    }

    public static bool IsSymmetric(TreeNode root)
    {
        if (root == null)
            return true;

        static bool IsSame(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return p == q;

            if (p.val != q.val)
                return false;

            return IsSame(p.left!, q.right!) && IsSame(p.right!, q.left!);
        }

        return IsSame(root.left!, root.right!);
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null || q == null)
            return p == q;

        if (p.val != q.val)
            return false;

        return IsSameTree(p.left!, q.left!) && IsSameTree(p.right!, q.right!);
    }

    public static IList<int>? InorderTraversal(TreeNode root)
    {
        if (root == null)
            return [];

        if (root.right == null && root.left == null)
            return [root.val];

        static IEnumerable<int> GetList(TreeNode tree)
        {
            if (tree.left != null)
                foreach (var child in GetList(tree.left))
                    yield return child;

            yield return tree.val;

            if (tree.right != null)
                foreach (var child in GetList(tree.right))
                    yield return child;
        }

        return GetList(root).ToList();
    }

    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        nums2.CopyTo(nums1, m);
        Array.Sort(nums1);

        #region it's bad
        //if (n == 0) return;

        //if (m == 0)
        //{
        //    Array.Copy(nums2, nums1, n);
        //    return;
        //}

        //int l1 = 0, l2 = 0;
        //Queue<int> nums = new();

        //while (l2 < n && l1 < m)
        //{
        //    nums.Enqueue(nums1[l1]);

        //    if (nums.Peek() < nums2[l2])
        //        nums1[l1++] = nums.Dequeue();
        //    else
        //        nums1[l1++] = nums2[l2++];
        //}

        //while (l1 < m)
        //{
        //    nums.Enqueue(nums1[l1]);
        //    nums1[l1++] = nums.Dequeue();
        //}

        //while (l2 < n)
        //    if (!nums.TryPeek(out int num))
        //        break;
        //    else if (num < nums2[l2])
        //        nums1[l1++] = nums.Dequeue();
        //    else
        //        nums1[l1++] = nums2[l2++];

        //while (l2 < n)
        //    nums1[l1++] = nums2[l2++];

        //while (nums.TryDequeue(out int num))
        //    nums1[l1++] = num;
        #endregion
    }

    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return null!;

        ListNode thisVal = head, result = thisVal;

        while (thisVal.next != null)
            if (thisVal.val == thisVal.next.val)
                thisVal.next = thisVal.next.next;
            else
                thisVal = thisVal.next;

        return result;
    }

    public static int ClimbStairs(int n)
    {
        var f = (1 + Math.Sqrt(5)) / 2;
        var pow = Math.Pow(f, n + 1);
        return (int)((pow - (1 / pow) * ((n + 1) % 2 == 0 ? 1 : -1)) / (2 * f - 1));
    }

    public static int MySqrt(int x)
    {
        if (x == 0 || x == 1)
            return x;

        int left = 1, right = x, mid;

        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (mid <= x / mid)
                left = mid + 1;
            else
                right = mid;
        }

        return left - 1;
    }

    public static string AddBinary(string a, string b)
    {
        if (b.Length > a.Length)
            (a, b) = (b, a);

        StringBuilder result = new(a);
        int dif = a.Length - b.Length;
        bool one = false;

        for (int i = b.Length - 1; i >= 0; i--)
            if (a[i + dif] == b[i])
                if (one)
                {
                    result[i + dif] = '1';

                    if (b[i] == '0')
                        one = false;
                }
                else
                {
                    result[i + dif] = '0';

                    if (b[i] == '1')
                        one = true;
                }
            else
                if (one)
                    result[i + dif] = '0';
                else
                    result[i + dif] = '1';

        if (one)
        {
            dif--;

            while(one && dif >= 0)
            {
                if (a[dif] == '0')
                {
                    result[dif] = '1';
                    return result.ToString();
                }
                else
                    result[dif] = '0';

                dif--;
            }

            return "1" + result.ToString();
        }

        return result.ToString();
    }

    public static int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] != 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }

        var result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }

    public static int LengthOfLastWord(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        int index = s.Length - 1;

        while (s[index] == ' ')
        {
            index--;

            if (index == -1)
                return 0;
        }

        int result = 0;

        while (s[index] != ' ')
        {
            result++;
            index--;

            if (index == -1)
                return result;
        }

        return result;
    }

    public static int SearchInsert(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int right = 0;
        int left = nums.Length;

        while (right <= left && right < nums.Length)
        {
            int mid = (right + left) / 2;

            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                right = mid + 1;
            else
                left = mid - 1;
        }

        return right;
    }

    public static int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle);
    }

    public static int RemoveElement(int[] nums, int val)
    {
        int result = 0;

        if (nums == null || nums.Length == 0)
            return 0;

        if (nums[0] == val)
            result = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == val)
                result++;
            else
                nums[i - result] = nums[i];
        }

        return nums.Length - result;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        int result = 0;
        int lastNumber = 101;

        for (int i = 0; i < nums.Length; i++)
        {
            if (lastNumber != nums[i])
                lastNumber = nums[i];
            else
                result++;

            nums[i - result] = nums[i];
        }

        return nums.Length - result;
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;

        if (list2 == null) return list1;

        ListNode thisVal, result;

        if (list1.val <= list2.val)
        {
            thisVal = result = list1;
            list1 = list1.next!;
        }
        else
        {
            thisVal = result = list2;
            list2 = list2.next!;
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
                list1 = list1.next!;
            }
            else
            {
                thisVal.next = list2;
                list2 = list2.next!;
            }

            thisVal = thisVal.next;
        }

        return result;
    }

    public static bool IsValid(string s)
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

    public static string LongestCommonPrefix(string[] strs)
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

    public static int RomanToInt(string s)
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

    public static bool IsPalindrome(int x)
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

    public static int[] TwoSum(int[] nums, int target)
    {
        var proofNums = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (proofNums.TryGetValue(target - nums[i], out int index))
                return [index, i];

            proofNums.TryAdd(nums[i], i);
        }

        return default!;
    }
}
