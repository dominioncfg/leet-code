namespace LeetCode.Tests;

/*
22. Generate Parentheses
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:
Input: n = 1
Output: ["()"]

Constraints:
    1 <= n <= 8
 */

public class GenerateParenthesesTests
{
    private readonly IGenerateParenthesisPermutations sut;

    public GenerateParenthesesTests()
    {
        sut = new GenerateParenthesisPermutations();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.GenerateParenthesis(3);
        result.Should().HaveCount(5);

        result.Should().Contain("((()))");
        result.Should().Contain("(()())");
        result.Should().Contain("(())()");
        result.Should().Contain("()(())");
        result.Should().Contain("()()()");
    }

    [Fact]
    public void Test2()
    {
        var result = sut.GenerateParenthesis(1);
        result.Should().HaveCount(1);

        result.Should().Contain("()");
    }


}