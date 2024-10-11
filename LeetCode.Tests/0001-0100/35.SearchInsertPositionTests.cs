namespace LeetCode.Tests;

/*
35. Search Insert Position

Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4

Constraints:
    1 <= nums.length <= 104
    -104 <= nums[i] <= 104
    nums contains distinct values sorted in ascending order.
    -104 <= target <= 104
 */

public class SearchInsertPositionTests
{
    private readonly ISearchInsertPosition sut;

    public SearchInsertPositionTests()
    {
        sut = new SearchInsertPosition();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.SearchInsert([1, 3, 5, 6], 5);
        result.Should().Be(2);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.SearchInsert([1, 3, 5, 6], 2);
        result.Should().Be(1);
    }


    [Fact]
    public void Test3()
    {
        var result = sut.SearchInsert([1, 3, 5, 6], 7);
        result.Should().Be(4);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.SearchInsert([1, 3, 5, 6, 8], 7);
        result.Should().Be(4);
    }

    [Fact]
    public void Test5()
    {
        var result = sut.SearchInsert([1, 3, 5, 6, 8], 0);
        result.Should().Be(0);
    }


    [Fact]
    public void Test6()
    {
        var result = sut.SearchInsert([-1, 3, 5, 6, 8], 0);
        result.Should().Be(1);
    }

    [Fact]
    public void Test7()
    {
        var result = sut.SearchInsert([1, 3], 2);
        result.Should().Be(1);
    }
}
