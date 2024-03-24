using System.Collections.Generic;

namespace LeetcodeSolutions.ExtensionClassesForSolutions;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int?[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
            return;

        var queue = new Queue<TreeNode>();
        var index = 0;

        void CompletedTree(ref int?[] values, TreeNode tree)
        {
            TreeNode? FillSide(ref int?[] values)
            {
                TreeNode? result = null;

                if (values[index] != null)
                {
                    result = new((int)values[index]!);
                    queue.Enqueue(result);
                }
                index++;

                return result;
            }

            tree.left = FillSide(ref values);

            if (index == values.Length) return;

            tree.right = FillSide(ref values);

            if (index == values.Length) return;

            CompletedTree(ref values, queue.Dequeue());
        }

        var newTree = new TreeNode((int)values[index++]!);
        val = newTree!.val;

        if (index == values.Length) return;
        CompletedTree(ref values, newTree);

        left = newTree.left;
        right = newTree.right;
    }

    public override bool Equals(object? obj)
    {
        static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return p == q;

            if (p.val != q.val)
                return false;

            return IsSameTree(p.left!, q.left!) && IsSameTree(p.right!, q.right!);
        }

        return IsSameTree((obj as TreeNode)!, this);
    }

    public override int GetHashCode()
    {
        throw new System.NotImplementedException();
    }
}
