namespace LeetCode.Tests;

/*
169. Majority Element

Given an array nums of size n, return the majority element.
The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

Example 1:
    Input: nums = [3,2,3]
    Output: 3

Example 2:
    Input: nums = [2,2,1,1,1,2,2]
    Output: 2

 

Constraints:
    n == nums.length
    1 <= n <= 5 * 10^4
    -10^9 <= nums[i] <= 10^9
 */

public class MajorityElementTests
{
    private readonly IMajorityElementCalculator sut;
    public MajorityElementTests()
    {
        sut = new MajorityElementCalculatorNoDictionary();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MajorityElement([3, 2, 3]);
        result.Should().Be(3);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.MajorityElement([2, 2, 1, 1, 1, 2, 2]);
        result.Should().Be(2);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.MajorityElement([4,2, 2, 1, 2,1, 1, 2, 2]);
        result.Should().Be(2);
    }
}