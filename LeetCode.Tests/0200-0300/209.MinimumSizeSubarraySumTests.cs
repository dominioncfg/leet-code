namespace LeetCode.Tests;

/*
209. Minimum Size Subarray Sum
Given an array of positive integers nums and a positive integer target, return the minimal length of a
subarray
whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

Example 1:
Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.

Example 2:
Input: target = 4, nums = [1,4,4]
Output: 1

Example 3:
Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0

Constraints:
    1 <= target <= 10^9
    1 <= nums.length <= 10^5
    1 <= nums[i] <= 10^4
 */

public class MinimumSizeSubarraySumTests
{
    private readonly IMinimumSizeSubarraySum sut;
    public MinimumSizeSubarraySumTests()
    {
        sut = new MinimumSizeSubarraySum();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MinSubArrayLen(7, [2, 3, 1, 2, 4, 3]);
        result.Should().Be(2);
    }


    [Fact]
    public void Test2()
    {
        var result = sut.MinSubArrayLen(4, [1, 4, 4]);
        result.Should().Be(1);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.MinSubArrayLen(11, [1, 1, 1, 1, 1, 1, 1, 1]);
        result.Should().Be(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.MinSubArrayLen(8, [4, 1, 2, 1, 5, 1]);
        result.Should().Be(3);
    }
}