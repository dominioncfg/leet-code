namespace LeetCode.Tests;

/*
875. Koko Eating Bananas

Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
Return the minimum integer k such that she can eat all the bananas within h hours.

Example 1:
Input: piles = [3,6,7,11], h = 8
Output: 4

Example 2:
Input: piles = [30,11,23,4,20], h = 5
Output: 30

Example 3:
Input: piles = [30,11,23,4,20], h = 6
Output: 23

Constraints:

    1 <= piles.length <= 10^4
    piles.length <= h <= 10^9
    1 <= piles[i] <= 10^9
 */

public class KokoEatingBananasTests
{
    private readonly IKokoEatingBananas sut;
    public KokoEatingBananasTests()
    {
        sut = new KokoEatingBananas();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MinEatingSpeed([3, 6, 7, 11],8);
        result.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.MinEatingSpeed([30, 11, 23, 4, 20], 5);
        result.Should().Be(30);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.MinEatingSpeed([30, 11, 23, 4, 20], 6);
        result.Should().Be(23);
    }
}
