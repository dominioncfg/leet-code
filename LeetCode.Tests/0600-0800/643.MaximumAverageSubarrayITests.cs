namespace LeetCode.Tests;

/*
643. Maximum Average Subarray I

You are given an integer array nums consisting of n elements, and an integer k.
Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.

Example 1:
Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

Example 2:
Input: nums = [5], k = 1
Output: 5.00000

Constraints:
    n == nums.length
    1 <= k <= n <= 10^5
    -10^4 <= nums[i] <= 10^4
 */

public class MaximumAverageSubarrayITests
{
    private readonly IMaximumAverageSubarrayI sut;
    public MaximumAverageSubarrayITests()
    {
        sut = new MaximumAverageSubarrayI();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.FindMaxAverage([1, 12, -5, -6, 50, 3],4);
        result.Should().BeApproximately(12.75, 0.00001); 
    }

    [Fact]
    public void Test2()
    {
        var result = sut.FindMaxAverage([5], 1);
        result.Should().BeApproximately(5,0.00001); 
    }

    [Fact]
    public void Test3()
    {
        var result = sut.FindMaxAverage([3, 3, 4, 3, 0], 3);
        result.Should().BeApproximately(3.33333, 0.00001);
    }


    [Fact]
    public void Test4()
    {
        var result = sut.FindMaxAverage([-6662, 5432, -8558, -8935, 8731, -3083, 4115, 9931, -4006, -3284, -3024, 1714, -2825, -2374, -2750, -959, 6516, 9356, 8040, -2169, -9490, -3068, 6299, 7823, -9767, 5751, -7897, 6680, -1293, -3486, -6785, 6337, -9158, -4183, 6240, -2846, -2588, -5458, -9576, -1501, -908, -5477, 7596, -8863, -4088, 7922, 8231, -4928, 7636, -3994, -243, -1327, 8425, -3468, -4218, -364, 4257, 5690, 1035, 6217, 8880, 4127, -6299, -1831, 2854, -4498, -6983, -677, 2216, -1938, 3348, 4099, 3591, 9076, 942, 4571, -4200, 7271, -6920, -1886, 662, 7844, 3658, -6562, -2106, -296, -3280, 8909, -8352, -9413, 3513, 1352, -8825], 90);
        result.Should().BeApproximately(37.25556, 0.00001);
    }


    [Fact]
    public void Test5()
    {
        var result = sut.FindMaxAverage([8535, -7482, -9148, 4029, 4086, -2863, -761, -1968, -9685, -6176, -1254, 2445, 1039, 2321, 917, -2641, -8077, 6421, 7040, 5340, 4639, 5261, -7277, 4932, 4253, -5315, 1561, -5930, -6204, -3061, 401, 7519, -9094, 7907, 847, 5083, 6096, -9552, 6772, 7985, -444, -2886, 6317, 4966, -6980], 45);
        result.Should().BeApproximately(220.31111, 0.00001);
    }
}
