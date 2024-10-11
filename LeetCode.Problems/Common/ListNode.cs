using System.Diagnostics;

[DebuggerDisplay("Value = {val}")]
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode FromEnumerable(IEnumerable<int> invertedDigits)
    {
        ListNode? result = null;
        foreach (var digit in invertedDigits.Reverse().ToList())
        {
            if (result is null)
            {
                result = new ListNode(digit);
            }
            else
            {
                result = new ListNode(digit, result);
            }
        }

        return result!;
    }

    public override bool Equals(object? obj)
    {
        if (obj is ListNode ln)
        {
            var thisNodeEnumerable = new List<int>();
            var otherNodeEnumerable = new List<int>();

            thisNodeEnumerable.AddRange(EnumarateList(this));
            otherNodeEnumerable.AddRange(EnumarateList(ln));

            if (thisNodeEnumerable.Count != otherNodeEnumerable.Count)
                return false;

            for (int i = 0; i < thisNodeEnumerable.Count; i++)
            {
                var item1 = thisNodeEnumerable[i];
                var item2 = otherNodeEnumerable[i];

                if (item1 != item2)
                    return false;
            }

            return true;

        }

        return base.Equals(obj);
    }

    private IEnumerable<int> EnumarateList(ListNode? listNode)
    {
        List<int> result = new List<int>();
        while (listNode is not null)
        {
            result.Add(listNode.val);
            listNode = listNode.next;
        }

        return result;
    }
}
