namespace LeetCode.Tests;

/*
55. Jump Game

You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
Return true if you can reach the last index, or false otherwise.

Example 1:
Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

Constraints:
    1 <= nums.length <= 10^4
    0 <= nums[i] <= 10^5
 */

public class JumpGameTests
{
    private readonly IJumpGame sut;
    public JumpGameTests()
    {
        sut = new JumpGameRecursive();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.CanJump([2, 3, 1, 1, 4]);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.CanJump([3, 2, 1, 0, 4]);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.CanJump([9, 0, 0, 0, 0, 0, 0, 0, 0, 1]);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test4()
    {
        var result = sut.CanJump([1,2]);
        result.Should().BeTrue();
    }

}