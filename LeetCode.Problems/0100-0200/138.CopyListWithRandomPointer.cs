using Node = ICopyListWithRandomPointer.Node;
public interface ICopyListWithRandomPointer
{
    public Node CopyRandomList(Node head);


    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}

public class CopyListWithRandomPointer : ICopyListWithRandomPointer
{
    public Node CopyRandomList(Node head)
    {
        if (head is null)
            return head;

        Dictionary<Node, Node> copies = new Dictionary<Node, Node>();
        var current = head;

        while(current is not null)
        {
            var copy = new Node(current.val);
            int hashCode =   current.GetHashCode();
            copies.Add(current,copy);
            current = current.next;
        }

        current = head;
        var newHead = copies[head];
        
        while(newHead is not null)
        {
            if(current.next is not null)
            {
                var nextNode = copies[current.next];
                newHead.next = nextNode;
            }

            if (current.random is not null)
            {
                var nextNode = copies[current.random];
                newHead.random = nextNode;
            }

            current = current.next;
            newHead = newHead.next;
        }
        
        return copies[head];
    }
}
