namespace LeetCode.Tests;

/*
704. Binary Search

Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1

Constraints:

    1 <= nums.length <= 104
    -104 < nums[i], target < 104
    All the integers in nums are unique.
    nums is sorted in ascending order.
 */

public class BinarySearchTests
{
    private readonly IBinarySearch sut;
    public BinarySearchTests()
    {
        sut = new BinarySearch();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Search([-1, 0, 3, 5, 9, 12], 9);
        result.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.Search([-1, 0, 3, 5, 9, 12], 2);
        result.Should().Be(-1);
    }


    [Fact]
    public void Test3()
    {
        var result = sut.Search([3, 5,], 3);
        result.Should().Be(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.Search([3, 5,], 5);
        result.Should().Be(1);
    }

    [Fact]
    public void Test5()
    {
        var result = sut.Search([3, 5, 6], 3);
        result.Should().Be(0);
    }

    [Fact]
    public void Test6()
    {
        var result = sut.Search([3, 5, 6], 5);
        result.Should().Be(1);
    }

    [Fact]
    public void Test7()
    {
        var result = sut.Search([3, 5, 6], 6);
        result.Should().Be(2);
    }
}
