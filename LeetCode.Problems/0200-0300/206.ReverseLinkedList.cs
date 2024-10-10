public interface IReverseLinkedList
{
    public ListNode? ReverseList(ListNode? head);
}


public class ReverseLinkedList : IReverseLinkedList
{
    public ListNode? ReverseList(ListNode? head)
    {
        if (head is null) 
            return null;

        var headResult = new ListNode(head.val);
        
        var current = head.next;

        while (current != null)
        {
            var reverse = new ListNode(current.val,headResult);
            headResult = reverse;
           current = current.next;
        }
        return headResult;
    }


}

public class ReverseLinkedListRecursive : IReverseLinkedList
{
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null || head.next == null)
            return head;

        // Reverse the rest of the list
        ListNode revHead = ReverseList(head.next);

        // Make the current head the last node
        head.next.next = head;

        // Update the next of current head to null
        head.next = null;

        // Return the new head of the reversed list
        return revHead;
    }


}


