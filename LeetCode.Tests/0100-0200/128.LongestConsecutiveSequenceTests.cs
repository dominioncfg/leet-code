﻿namespace LeetCode.Tests;

/*
128. Longest Consecutive Sequence

Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
You must write an algorithm that runs in O(n) time.

Example 1:
    Input: nums = [100,4,200,1,3,2]
    Output: 4 
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Example 2:
    Input: nums = [0,3,7,2,5,8,4,6,0,1]
    Output: 9

Constraints:
    0 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9
 */

public class LongestConsecutiveSequenceTests
{
    private readonly ILongestConsecutiveSequence sut;
    public LongestConsecutiveSequenceTests()
    {
        sut = new LongestConsecutiveSequence();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.LongestConsecutive([100, 4, 200, 1, 3, 2]);
        result.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.LongestConsecutive([0, 3, 7, 2, 5, 8, 4, 6, 0, 1]);
        result.Should().Be(9);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.LongestConsecutive([]);
        result.Should().Be(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.LongestConsecutive([2]);
        result.Should().Be(1);
    }
}