namespace LeetCode.Tests;

/*
19. Remove Nth Node From End of List

Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]

Example 2:

Input: head = [1], n = 1
Output: []

Example 3:
Input: head = [1,2], n = 1
Output: [1]

Constraints:
    The number of nodes in the list is sz.
    1 <= sz <= 30
    0 <= Node.val <= 100
    1 <= n <= sz
 */

public class RemoveNthNodeFromEndOfListTests
{
    private readonly IRemoveNthNodeFromEndOfList sut;

    public RemoveNthNodeFromEndOfListTests()
    {
        sut = new RemoveNthNodeFromEndOfListPointersSolution();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.RemoveNthFromEnd(ListNode.FromEnumerable([1, 2, 3, 4, 5]), 2);
        result.Should().Be(ListNode.FromEnumerable([1, 2, 3, 5]));
    }

    [Fact]
    public void Test2()
    {
        var result = sut.RemoveNthFromEnd(ListNode.FromEnumerable([1]), 1);
        result.Should().Be(ListNode.FromEnumerable([]));
    }

    [Fact]
    public void Test3()
    {
        var result = sut.RemoveNthFromEnd(ListNode.FromEnumerable([1,2]), 1);
        result.Should().Be(ListNode.FromEnumerable([1]));
    }

}