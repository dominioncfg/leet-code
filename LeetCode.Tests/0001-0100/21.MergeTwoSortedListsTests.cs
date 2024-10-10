namespace LeetCode.Tests;

/*
21. Merge Two Sorted Lists

You are given the heads of two sorted linked lists list1 and list2.
Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
Return the head of the merged linked list.

Example 1:
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Example 2:
Input: list1 = [], list2 = []
Output: []

Example 3:
Input: list1 = [], list2 = [0]
Output: [0]

 

Constraints:

    The number of nodes in both lists is in the range [0, 50].
    -100 <= Node.val <= 100
    Both list1 and list2 are sorted in non-decreasing order.


 */

public class MergeTwoSortedListsTests
{
    private readonly IMergeTwoSortedLists sut;

    public MergeTwoSortedListsTests()
    {
        sut = new MergeTwoSortedListsRecursive();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MergeTwoLists(ListNode.FromEnumerable([1, 2, 4]), ListNode.FromEnumerable([1, 3, 4]));
        result.Should().Be(ListNode.FromEnumerable([1, 1, 2, 3, 4, 4]));
    }

    [Fact]
    public void Test2()
    {
        var result = sut.MergeTwoLists(ListNode.FromEnumerable([]), ListNode.FromEnumerable([]));
        result.Should().Be(ListNode.FromEnumerable([]));
    }


    [Fact]
    public void Test3()
    {
        var result = sut.MergeTwoLists(ListNode.FromEnumerable([]), ListNode.FromEnumerable([0]));
        result.Should().Be(ListNode.FromEnumerable([0]));
    }


    [Fact]
    public void Test4()
    {
        var result = sut.MergeTwoLists(ListNode.FromEnumerable([0]), ListNode.FromEnumerable([]));
        result.Should().Be(ListNode.FromEnumerable([0]));
    }


}