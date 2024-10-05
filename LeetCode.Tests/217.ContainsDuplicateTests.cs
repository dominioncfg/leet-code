namespace LeetCode.Tests;

/*
217. Contains Duplicate

Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

 

Example 1:
Input: nums = [1,2,3,1]
Output: true
Explanation:
The element 1 occurs at the indices 0 and 3.

Example 2:
Input: nums = [1,2,3,4]
Output: false
Explanation:
All elements are distinct.

Example 3:
Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true

Constraints:

    1 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9
 */

public class ContainsDuplicateTests
{
    private readonly IContainsDuplicate sut;
    public ContainsDuplicateTests()
    {
        sut = new ContainsDuplicateCalculator();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.ContainsDuplicate([1, 2, 3, 1]);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.ContainsDuplicate([1, 2, 3, 4]);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.ContainsDuplicate([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]);
        result.Should().BeTrue();
    }
}