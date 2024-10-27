public interface IMergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists);
}

public class MergeKSortedLists : IMergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists is null || lists.Length == 0)
            return null;


        var queue = new PriorityQueue<int, int>();
        foreach (ListNode list in lists)
        {
            var current = list;

            while (current is not null) 
            {
                queue.Enqueue(current.val,current.val);
                current = current.next;
            }

        }

        if(queue.Count==0)
            return null;    

        var rootVal = queue.Dequeue();

        var result = new ListNode(rootVal); 

        var currentNode = result;
        while(queue.Count>0)
        {
            var nextValue = queue.Dequeue();
            currentNode.next = new ListNode(nextValue);
            currentNode = currentNode.next;
        }


       return result;

    }
}


