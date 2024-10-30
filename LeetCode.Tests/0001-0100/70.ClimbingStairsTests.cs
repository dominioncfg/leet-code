namespace LeetCode.Tests;

/*
70. Climbing Stairs

You are climbing a staircase. It takes n steps to reach the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step

Constraints:

    1 <= n <= 45
 */

public class ClimbingStairsTests
{
    private readonly IClimbingStairs sut;
    public ClimbingStairsTests()
    {
        sut = new ClimbingStairsIterative();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.ClimbStairs(2);
        result.Should().Be(2);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.ClimbStairs(3);
        result.Should().Be(3);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.ClimbStairs(45);
        result.Should().Be(1836311903);
    }
}