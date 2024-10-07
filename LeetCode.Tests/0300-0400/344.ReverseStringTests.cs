namespace LeetCode.Tests;

/*
344. Reverse String

Write a function that reverses a string. The input string is given as an array of characters s.
You must do this by modifying the input array in-place with O(1) extra memory.

Example 1:
    Input: s = ["h","e","l","l","o"]
    Output: ["o","l","l","e","h"]

Example 2:
    Input: s = ["H","a","n","n","a","h"]
    Output: ["h","a","n","n","a","H"]

Constraints:
    1 <= s.length <= 105
    s[i] is a printable ascii character.
 */

public class ReverseStringTests
{
    private readonly IStringReverser sut;
    public ReverseStringTests()
    {
        sut = new StringReverser();
    }

    [Fact]
    public void Test1()
    {
        char[] str = ['h', 'e', 'l', 'l', 'o'];
        sut.ReverseString(str);
        str.Should().BeEquivalentTo(['o', 'l', 'l', 'e', 'h'], options=>options.WithStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        char[] str = ['h', 'e', 'l', 'o'];
        sut.ReverseString(str);
        str.Should().BeEquivalentTo(['o', 'l', 'e', 'h'], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        char[] str = ['H', 'a', 'n', 'n', 'a', 'h'];
        sut.ReverseString(str);
        str.Should().BeEquivalentTo(['h', 'a', 'n', 'n', 'a', 'H'], options => options.WithStrictOrdering());
    }
}