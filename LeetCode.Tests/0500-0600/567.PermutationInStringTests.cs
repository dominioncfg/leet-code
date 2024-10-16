namespace LeetCode.Tests;

/*
567. Permutation in String
Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
In other words, return true if one of s1's permutations is the substring of s2.

Example 1:
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").

Example 2:
Input: s1 = "ab", s2 = "eidboaoo"
Output: false

Constraints:
    1 <= s1.length, s2.length <= 10^4
    s1 and s2 consist of lowercase English letters.
 */

public class PermutationInStringTests
{
    private readonly IPermutationInString sut;
    public PermutationInStringTests()
    {
        sut = new PermutationInString();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.CheckInclusion("ab", "eidbaooo");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.CheckInclusion("ab", "eidboaoo");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.CheckInclusion("abo", "eidboaoo");
        result.Should().BeTrue();
    }


    [Fact]
    public void Test4()
    {
        var result = sut.CheckInclusion("aboa", "eidbaoaoo");
        result.Should().BeTrue();
    }



    [Fact]
    public void Test5()
    {
        var result = sut.CheckInclusion("aboa", "essssabidbaoaoo");
        result.Should().BeTrue();
    }


    [Fact]
    public void Test6()
    {
        var result = sut.CheckInclusion("abo", "essssabai");
        result.Should().BeFalse();
    }


    [Fact]
    public void Test7()
    {
        var result = sut.CheckInclusion("abo", "essssabao");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test8()
    {
        var result = sut.CheckInclusion("adc", "dcda");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test9()
    {
        var result = sut.CheckInclusion("hello", "ooolleoooleh");
        result.Should().BeFalse();
    }
}