namespace LeetCode.Tests;

/*
300. Longest Increasing Subsequence
Given an integer array nums, return the length of the longest strictly increasing subsequence.

Example 1:
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

Example 2:
Input: nums = [0,1,0,3,2,3]
Output: 4

Example 3:
Input: nums = [7,7,7,7,7,7,7]
Output: 1

Constraints:
    1 <= nums.length <= 2500
    -10^4 <= nums[i] <= 10^4
 */

public class LongestIncreasingSubsequenceTests
{
    private readonly ILongestIncreasingSubsequence sut;
    public LongestIncreasingSubsequenceTests()
    {
        sut = new LongestIncreasingSubsequence();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.LengthOfLIS([10, 9, 2, 5, 3, 7, 101, 18]);
        result.Should().Be(4);
    }


    [Fact]
    public void Test2()
    {
        var result = sut.LengthOfLIS([0, 1, 0, 3, 2, 3]);
        result.Should().Be(4);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.LengthOfLIS([7, 7, 7, 7, 7, 7, 7]);
        result.Should().Be(1);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.LengthOfLIS([10, 9, 2, 5, 3, 7, 1 , 101, 18]);
        result.Should().Be(4);
    }

    [Fact]
    public void Test5()
    {
        var result = sut.LengthOfLIS([10]);
        result.Should().Be(1);
    }


    [Fact]
    public void Test6()
    {
        var result = sut.LengthOfLIS([1, 3, 6, 7, 9, 4, 10, 5, 6]);
        result.Should().Be(6);
    }

}