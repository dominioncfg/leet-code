namespace LeetCode.Tests;

/*
20. Valid Parentheses

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.


Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Example 4:
Input: s = "([])"
Output: true

Constraints:

    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.
 */

public class ValidParenthesesTests
{
    private readonly IValidParentheses sut;
    
    public ValidParenthesesTests()
    {
        sut = new ValidParentheses();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.IsValid("()");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.IsValid("()[]{}");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.IsValid("(]");
        result.Should().BeFalse();
    }


    [Fact]
    public void Test4()
    {
        var result = sut.IsValid("([])");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test5()
    {
        var result = sut.IsValid("[");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test6()
    {
        var result = sut.IsValid("]");
        result.Should().BeFalse();
    }

}