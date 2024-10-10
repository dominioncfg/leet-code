public interface ILinkedListCycle
{
    public bool HasCycle(LinkedListCycleNode? head);

}

public class LinkedListCycle : ILinkedListCycle
{
    public bool HasCycle(LinkedListCycleNode? head)
    {
        HashSet<LinkedListCycleNode> nodes = new HashSet<LinkedListCycleNode>();
        while (head != null)
        {
            var addResult = nodes.Add(head);
            if (!addResult)
                return true;
            head = head.next;
        }
        return false;
    }
}


public class LinkedListCycleSlowAndFastPointerSolution : ILinkedListCycle
{
    public bool HasCycle(LinkedListCycleNode? head)
    {
        var slowPointer = head;
        if (head == null || head.next == null)
        {
            return false;
        }
        var fastPointer = head.next;
        while (slowPointer != fastPointer)
        {
            if (fastPointer.next != null && fastPointer.next.next != null)
            {
                fastPointer = fastPointer.next.next;
                slowPointer = slowPointer.next;
            }
            else
            {
                return false;
            }

        }
        return true;
    }
}

public class LinkedListCycleNode
{
    public int val;
    public LinkedListCycleNode? next;
    public LinkedListCycleNode(int val = 0, LinkedListCycleNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static LinkedListCycleNode FromEnumerable(IEnumerable<int> invertedDigits)
    {
        LinkedListCycleNode? result = null;
        foreach (var digit in invertedDigits.Reverse().ToList())
        {
            if (result is null)
            {
                result = new LinkedListCycleNode(digit);
            }
            else
            {
                result = new LinkedListCycleNode(digit, result);
            }
        }

        return result!;
    }
}