namespace LeetCode.Tests;

/*
83. Remove Duplicates from Sorted List

Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.

Example 1:

Input: head = [1,1,2]
Output: [1,2]

Example 2:
Input: head = [1,1,2,3,3]
Output: [1,2,3]

Constraints:
    The number of nodes in the list is in the range [0, 300].
    -100 <= Node.val <= 100
    The list is guaranteed to be sorted in ascending order.
 */

public class RemoveDuplicatesFromSortedListTests
{
    private readonly IRemoveDuplicatesFromSortedList sut;
    public RemoveDuplicatesFromSortedListTests()
    {
        sut = new RemoveDuplicatesFromSortedList();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.DeleteDuplicates(ListNode.FromEnumerable([1, 1, 2]));
        result.Should().Be(ListNode.FromEnumerable([1, 2]));
    }


    [Fact]
    public void Test2()
    {
        var result = sut.DeleteDuplicates(ListNode.FromEnumerable([1, 1, 2, 3, 3]));
        result.Should().Be(ListNode.FromEnumerable([1, 2, 3]));
    }

    [Fact]
    public void Test3()
    {
        var result = sut.DeleteDuplicates(ListNode.FromEnumerable([1, 1, 1]));
        result.Should().Be(ListNode.FromEnumerable([1]));
    }
}