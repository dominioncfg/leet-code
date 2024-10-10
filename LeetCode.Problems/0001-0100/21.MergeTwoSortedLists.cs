public interface IMergeTwoSortedLists
{
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2);
}

public class MergeTwoSortedLists : IMergeTwoSortedLists
{
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        var currentTail = new ListNode(int.MinValue);
        var headPlaceHolder = currentTail;

        while (list1 is not null || list2 is not null)
        {
            var shouldUseList1 = (list1?.val ?? int.MaxValue) <= (list2?.val ?? int.MaxValue);
            if (shouldUseList1)
            {
                currentTail.next = list1;
                list1 = list1.next;
                currentTail = currentTail.next;
            }
            else
            {
                currentTail.next = list2;
                list2 = list2.next;
                currentTail = currentTail.next;
            }
        }

        if (currentTail is not null)
            currentTail.next = null;

        return headPlaceHolder.next;
    }
}


public class MergeTwoSortedListsRecursive : IMergeTwoSortedLists
{
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null)
            return list2;

        if (list2 is null)
            return list1;


        var shouldUseList1 = (list1?.val ?? int.MaxValue) <= (list2?.val ?? int.MaxValue);
        if (shouldUseList1)
        {
            var mergeResult = MergeTwoLists(list1.next, list2);
            list1.next = mergeResult;
            return list1;
        }
        else
        {
            var mergeResult = MergeTwoLists(list1, list2.next);
            list2.next = mergeResult;
            return list2;
        }

    }
}
