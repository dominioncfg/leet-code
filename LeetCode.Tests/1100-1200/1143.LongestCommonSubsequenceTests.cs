﻿namespace LeetCode.Tests;

/*
1143. Longest Common Subsequence

Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.

A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.
For example, "ace" is a subsequence of "abcde".
A common subsequence of two strings is a subsequence that is common to both strings.

Example 1:
Input: text1 = "abcde", text2 = "ace" 
Output: 3  
Explanation: The longest common subsequence is "ace" and its length is 3.

Example 2:
Input: text1 = "abc", text2 = "abc"
Output: 3
Explanation: The longest common subsequence is "abc" and its length is 3.

Example 3:
Input: text1 = "abc", text2 = "def"
Output: 0
Explanation: There is no such common subsequence, so the result is 0.

Constraints:

    1 <= text1.length, text2.length <= 1000
    text1 and text2 consist of only lowercase English characters.
*/

public class LongestCommonSubsequenceTests
{
    private readonly ILongCommonSubsequence sut;
    public LongestCommonSubsequenceTests()
    {
        sut = new LongCommonSubsequence();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.LongestCommonSubsequence("abcde", "ace");
        result.Should().Be(3);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.LongestCommonSubsequence("abc", "abc");
        result.Should().Be(3);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.LongestCommonSubsequence("abc", "def");
        result.Should().Be(0);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.LongestCommonSubsequence("mhunuzqrkzsnidwbun", "szulspmhwpazoxijwbq");
        result.Should().Be(6);
    }
}