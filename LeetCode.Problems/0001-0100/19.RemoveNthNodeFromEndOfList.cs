public interface IRemoveNthNodeFromEndOfList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n);
}

public class RemoveNthNodeFromEndOfListPointersSolution : IRemoveNthNodeFromEndOfList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var result = new ListNode(-1, head);
        var ahead = result;
        var behind = result;

        for (int i = 0; i <= n; i++)
        {
            ahead = ahead.next;
        }

        while (ahead is not null)
        {
            ahead = ahead.next;
            behind = behind.next;
        }

        behind.next = behind.next.next;
        return result.next;
    }
}


public class RemoveNthNodeFromEndOfListTrivial : IRemoveNthNodeFromEndOfList
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        List<int> values = new List<int>();
        var current = head;
        while (current != null)
        {
            values.Add(current.val);
            current = current.next;
        }

        values.RemoveAt(values.Count - n);

        return FromEnumerable(values);
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
}

//There is a better solution by sorting the array.