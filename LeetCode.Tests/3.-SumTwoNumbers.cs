namespace LeetCode.Tests;

/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 */

public class SumTwoNumbersTests
{
    private readonly ISumTwoNumbers sut;
    public SumTwoNumbersTests()
    {
        sut = new SumTwoNumbersNaturalSum();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.AddTwoNumbersWithInvertedDigits(ListNode.FromEnumerable([2, 4, 3]), ListNode.FromEnumerable([5, 6, 4]));
        result.Should().Be(ListNode.FromEnumerable([7, 0, 8]));
    }


    [Fact]
    public void Test2()
    {
        var result = sut.AddTwoNumbersWithInvertedDigits(ListNode.FromEnumerable([0]), ListNode.FromEnumerable([0]));
        result.Should().Be(ListNode.FromEnumerable([0]));
    }

    [Fact]
    public void Test3()
    {
        var result = sut.AddTwoNumbersWithInvertedDigits(ListNode.FromEnumerable([9, 9, 9, 9, 9, 9, 9]), ListNode.FromEnumerable([9, 9, 9, 9]));
        result.Should().Be(ListNode.FromEnumerable([8, 9, 9, 9, 0, 0, 0, 1]));
    }

    [Fact]
    public void Test4()
    {
        var result = sut.AddTwoNumbersWithInvertedDigits(ListNode.FromEnumerable([9]), ListNode.FromEnumerable([1, 9, 9, 9, 9, 9, 9, 9, 9, 9]));
        result.Should().Be(ListNode.FromEnumerable([0,0,0,0,0,0,0,0,0,0,1]));
    }
}