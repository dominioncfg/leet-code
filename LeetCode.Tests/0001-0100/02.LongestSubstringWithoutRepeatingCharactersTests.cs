namespace LeetCode.Tests;

/*
Given a string s, find the length of the longest
substring
without repeating characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

 

Constraints:

    0 <= s.length <= 5 * 104
    s consists of English letters, digits, symbols and spaces.
 */

public class LongestSubstringWithoutRepeatingCharactersTests
{
    private readonly ILongestSubstringWithoutRepeatingCharacters sut;
    public LongestSubstringWithoutRepeatingCharactersTests()
    {
        sut = new LongestSubstringWithoutRepeatingCharactersMovingSlidingDictionaryWindow();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.LengthOfLongestSubstring("abcabcbb");
        result.Should().Be(3);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.LengthOfLongestSubstring("bbbbb");
        result.Should().Be(1);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.LengthOfLongestSubstring("pwwkew");
        result.Should().Be(3);
    }

    [Fact]
    public void Test4()
    {
        var result = sut.LengthOfLongestSubstring("bccb");
        result.Should().Be(2);
    }

    [Fact]
    public void Test5()
    {
        var result = sut.LengthOfLongestSubstring(" ");
        result.Should().Be(1);
    }

    [Fact]
    public void Test6()
    {
        var result = sut.LengthOfLongestSubstring("dvdf");
        result.Should().Be(3);
    }

    [Fact]
    public void Test7()
    {
        var result = sut.LengthOfLongestSubstring("bbbbb");
        result.Should().Be(1);
    }
    
}