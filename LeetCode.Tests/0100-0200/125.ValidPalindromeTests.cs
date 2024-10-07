namespace LeetCode.Tests;

/*
125. Valid Palindrome

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

Example 1:
    Input: s = "A man, a plan, a canal: Panama"
    Output: true
    Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
    Input: s = "race a car"
    Output: false
    Explanation: "raceacar" is not a palindrome.

Example 3:
    Input: s = " "
    Output: true
    Explanation: s is an empty string "" after removing non-alphanumeric characters.
    Since an empty string reads the same forward and backward, it is a palindrome.

 
Constraints:
    1 <= s.length <= 2 * 105
    s consists only of printable ASCII characters.
 */

public class ValidPalindromeTests
{
    private readonly IValidPalindrome sut;
    public ValidPalindromeTests()
    {
        sut = new ValidPalindrome();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.IsPalindrome("A man, a plan, a canal: Panama");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.IsPalindrome("race a car");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.IsPalindrome("A man, a plan, a canal: Panama");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test4()
    {
        var result = sut.IsPalindrome(".,");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test5()
    {
        var result = sut.IsPalindrome("0P");
        result.Should().BeFalse();
    }

}