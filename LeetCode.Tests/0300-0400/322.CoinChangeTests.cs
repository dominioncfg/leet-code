namespace LeetCode.Tests;

/*
322. Coin Change

You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
You may assume that you have an infinite number of each kind of coin.

Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0

Constraints:
    1 <= coins.length <= 12
    1 <= coins[i] <= 2^31 - 1
    0 <= amount <= 104

 */

public class CoinChangeTests
{
    private readonly ICoinChanger sut;
    public CoinChangeTests()
    {
        sut = new CoinChangerDpBottomUpTabulation();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.CoinChange([1, 2, 5], 11);
        result.Should().Be(3);
    }


    [Fact]
    public void Test2()
    {
        var result = sut.CoinChange([2], 3);
        result.Should().Be(-1);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.CoinChange([1], 0);
        result.Should().Be(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.CoinChange([2, 5, 10, 1], 27);
        result.Should().Be(4);
    }

    [Fact]
    public void Test5()
    {
        var result = sut.CoinChange([186, 419, 83, 408], 6249);
        result.Should().Be(20);
    }    
}