namespace LeetCode.Tests;

/*
242. Valid Anagram

Given two strings s and t, return true if t is an anagram of s, and false otherwise.


Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false

Constraints:

    1 <= s.length, t.length <= 5 * 104
    s and t consist of lowercase English letters.
 */

public class ValidAnagramTests
{
    private readonly IValidAnagram sut;
    public ValidAnagramTests()
    {
        sut = new ValidAnagram();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.IsAnagram("anagram", "nagaram");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.IsAnagram("rat", "car");
        result.Should().BeFalse();
    }
}