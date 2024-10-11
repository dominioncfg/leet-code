namespace LeetCode.Tests;

/*
876. Middle of the Linked List

Given the head of a singly linked list, return the middle node of the linked list.
If there are two middle nodes, return the second middle node.

Example 1:
Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.

Example 2:
Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.

Constraints:

    The number of nodes in the list is in the range [1, 100].
    1 <= Node.val <= 100
 */

public class MiddleOfTheLinkedListTests
{
    private readonly IMiddleOFLinkedList sut;
    public MiddleOfTheLinkedListTests()
    {
        sut = new MiddleOFLinkedList();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MiddleNode(ListNode.FromEnumerable([1,2,3,4,5]));
        result.Should().NotBeNull();
        result.val.Should().Be(3);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.MiddleNode(ListNode.FromEnumerable([1, 2, 3, 4, 5, 6]));
        result.Should().NotBeNull();
        result.val.Should().Be(4);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.MiddleNode(ListNode.FromEnumerable([]));
        result.Should().BeNull();
    }

    [Fact]
    public void Test4()
    {
        var result = sut.MiddleNode(ListNode.FromEnumerable([1]));
        result.Should().NotBeNull();
        result.val.Should().Be(1);
    }
}
