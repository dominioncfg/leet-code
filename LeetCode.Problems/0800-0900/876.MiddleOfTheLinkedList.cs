public interface IMiddleOFLinkedList
{
    public ListNode? MiddleNode(ListNode? head);
}

public class MiddleOFLinkedList : IMiddleOFLinkedList
{
    public ListNode? MiddleNode(ListNode? head)
    {
        if (head is null || head.next is null)
            return head;
        var slowPointer = head;
        var fastPointer = head.next;
       
        while (fastPointer.next is not null && fastPointer.next.next is not null)
        {
                fastPointer = fastPointer.next.next;
                slowPointer = slowPointer.next;
        }
        return slowPointer.next;
    }
}
