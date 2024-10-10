public interface IRemoveDuplicatesFromSortedList
{
    public ListNode? DeleteDuplicates(ListNode head);
}


public class RemoveDuplicatesFromSortedList : IRemoveDuplicatesFromSortedList
{
    public ListNode? DeleteDuplicates(ListNode head)
    {
        if(head is null)
            return head;

        var current = head;
        while (current?.next is not null)
        {
            if (current.next.val == current.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return head;
    }
}


public class RemoveDuplicatesFromSortedListRecursive: IRemoveDuplicatesFromSortedList
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;

        head.next = DeleteDuplicates(head.next);
        if (head.val == head.next.val) return head.next;
        else return head;
    }
}