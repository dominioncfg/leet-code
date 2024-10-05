namespace LeetCode.Tests;

/*
 14. Longest Common Prefix

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

 

Constraints:

    1 <= strs.length <= 200
    0 <= strs[i].length <= 200
    strs[i] consists of only lowercase English letters.
 */

public class LongestCommonPrefixTests
{
    private readonly ILongestCommonPrefixCalculator sut;
    public LongestCommonPrefixTests()
    {
        sut = new LongestCommonPrefixCalculator();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.LongestCommonPrefix(["flower", "flow", "flight"]);
        result.Should().Be("fl");
    }

    [Fact]
    public void Test2()
    {
        var result = sut.LongestCommonPrefix(["dog", "racecar", "car"]);
        result.Should().Be("");
    }

    [Fact]
    public void Test3()
    {
        var result = sut.LongestCommonPrefix(["do", "dog", "do"]);
        result.Should().Be("do");
    }

}