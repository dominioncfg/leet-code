namespace LeetCode.Tests;

/*
1189. Maximum Number of Balloons

Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.
You can use each character in text at most once. Return the maximum number of instances that can be formed.

Example 1:
Input: text = "nlaebolko"
Output: 1

Example 2:
Input: text = "loonbalxballpoon"
Output: 2

Example 3:
Input: text = "leetcode"
Output: 0

Constraints:
    1 <= text.length <= 10^4
    text consists of lower case English letters only.
 */

public class MaximumNumberOfBalloonsTests
{
    private readonly IMaximumNumberOfBalloons sut;
    public MaximumNumberOfBalloonsTests()
    {
        sut = new MaximumNumberOfBalloons();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.MaxNumberOfBalloons("nlaebolko");
        result.Should().Be(1);
    }

    [Fact]
    public void Test2()
    {
        var result = sut.MaxNumberOfBalloons("loonbalxballpoon");
        result.Should().Be(2);
    }

    [Fact]
    public void Test3()
    {
        var result = sut.MaxNumberOfBalloons("leetcode");
        result.Should().Be(0);
    }
}