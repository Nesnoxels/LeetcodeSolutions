namespace LeetcodeSolutions.ExtensionClassesForSolutions
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(ref int[] values)
        {
            if (values == null)
                return;

            var newList = CompliteList(ref values);

            val = newList.val;
            next = newList.next;
        }

        private ListNode CompliteList(ref int[] values, int index = 0)
        {
            var newList = new ListNode(values[index]);

            if (values.Length - 1 == index)
                return newList;

            next = CompliteList(ref values, index + 1);

            return newList;
        }

        public override bool Equals(object? obj)
        {
            var checkedList = obj as ListNode;
            var thisList = this;

            while (checkedList.next != null && checkedList != null)
                if (checkedList.val != thisList.val)
                    return false;
                else
                {
                    checkedList = checkedList.next;
                    thisList = thisList.next;
                }

            if (checkedList != null ^ thisList != null)
                return false;

            return true;
        }
    }
}
