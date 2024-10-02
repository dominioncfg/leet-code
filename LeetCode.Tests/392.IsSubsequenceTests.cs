namespace LeetCode.Tests;

/*
Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

 

Example 1:

Input: s = "abc", t = "ahbgdc"
Output: true

Example 2:

Input: s = "axc", t = "ahbgdc"
Output: false

 

Constraints:

    0 <= s.length <= 100
    0 <= t.length <= 104
    s and t consist only of lowercase English letters.


 */

public class IsSubsequenceTests
{
    private readonly IIsSubsequenceCalculator sut;
    public IsSubsequenceTests()
    {
        sut = new IsSubsequenceCalculator();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.IsSubsequence("abc", "ahbgdc");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.IsSubsequence("axc", "ahbgdc");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.IsSubsequence("ace", "abcde");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test4()
    {
        var result = sut.IsSubsequence("aec", "abcde");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test5()
    {
        var result = sut.IsSubsequence("ace", "aczasddscde");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test6()
    {
        var result = sut.IsSubsequence("", "ahbgdc");
        result.Should().BeTrue();
    }


    [Fact]
    public void Test7()
    {
        var result = sut.IsSubsequence("ace", "");
        result.Should().BeFalse();
    }

}