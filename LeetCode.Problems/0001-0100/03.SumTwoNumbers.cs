

using System.Text;

public interface ISumTwoNumbers
{
    public ListNode AddTwoNumbersWithInvertedDigits(ListNode l1, ListNode l2);
}

public class SumTwoNumbersGreedy : ISumTwoNumbers
{
    public ListNode AddTwoNumbersWithInvertedDigits(ListNode l1, ListNode l2)
    {
        var l1Parsed = ParseInvertedListNode(l1);
        var l2Parsed = ParseInvertedListNode(l2);

        var sumResult = l1Parsed + l2Parsed;

        var result = ToListNodeInverted(sumResult);
        return result!;
    }

    private long ParseInvertedListNode(ListNode l1)
    {
        StringBuilder sb = new StringBuilder();

        ListNode? currentNode = l1;
        while (currentNode is not null)
        {
            sb.Insert(0, currentNode.val);
            currentNode = currentNode.next;
        }

        return long.Parse(sb.ToString());
    }

    private ListNode? ToListNodeInverted(long result)
    {
        var str = result.ToString();
        ListNode? currentNode = null;
        foreach (var digit in str)
        {
            currentNode = new ListNode(int.Parse(digit.ToString()), currentNode);
        }
        return currentNode;
    }
}


public class SumTwoNumbersNaturalSum : ISumTwoNumbers
{
    public ListNode AddTwoNumbersWithInvertedDigits(ListNode l1, ListNode l2)
    {
        ListNode? currentNode1 = l1;
        ListNode? currentNode2 = l2;


        ListNode? headResult = null;
        ListNode? currentNodeResult = null;

        int rest = 0;
        while (currentNode1 is not null || currentNode2 is not null || rest> 0)
        {
            int currentNode1Operand = currentNode1?.val ?? 0;
            int currentNode2Operand = currentNode2?.val ?? 0;

            var nextNodeValue = currentNode1Operand + currentNode2Operand + rest;

            rest = nextNodeValue / 10;

            var newNode = new ListNode(nextNodeValue % 10);

            if (headResult is null)
                headResult = newNode;

            if (currentNodeResult is not null)
            {
                currentNodeResult.next = newNode;
            }
            currentNodeResult = newNode;


            currentNode1 = currentNode1?.next;
            currentNode2 = currentNode2?.next;
        }
        
        return headResult!;
    }


}