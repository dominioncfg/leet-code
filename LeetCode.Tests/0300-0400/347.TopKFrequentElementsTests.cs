﻿namespace LeetCode.Tests;

/*
347. Top K Frequent Elements
Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:
Input: nums = [1], k = 1
Output: [1]

Constraints:

    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4
    k is in the range [1, the number of unique elements in the array].
    It is guaranteed that the answer is unique.
 */

public class TopKFrequentElementsTests
{
    private readonly ITopKFrequentElements sut;
    public TopKFrequentElementsTests()
    {
        sut = new TopKFrequentElementsNSolution();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.TopKFrequent([1, 1, 1, 2, 2, 3], 2);
        result.Should().BeEquivalentTo([1, 2]);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.TopKFrequent([1], 1);
        result.Should().BeEquivalentTo([1]);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.TopKFrequent([1,2], 2);
        result.Should().BeEquivalentTo([1, 2]);
    }
}