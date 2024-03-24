namespace LeetcodeSolutions.ExtensionClassesForSolutions;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode(ref int[] values)
    {
        if (values == null || values.Length == 0)
            return;

        var newList = CompletedList(ref values);

        val = newList!.val;
        next = newList.next;
    }

    private static ListNode? CompletedList(ref int[] values, int index = 0)
    {
        if (index >= values.Length)
            return null;

        var newList = new ListNode(values[index],
            CompletedList(ref values, index + 1));

        return newList;
    }

    public override bool Equals(object? obj)
    {
        static bool IsSameList(ListNode? p, ListNode? q)
        {
            if (p == null || q == null)
                return p == q;

            if (p.val != q.val)
                return false;

            return IsSameList(p.next, q.next);
        }

        return IsSameList(this, (obj as ListNode)!);
    }

    public override int GetHashCode()
    {
        throw new System.NotImplementedException();
    }
}
