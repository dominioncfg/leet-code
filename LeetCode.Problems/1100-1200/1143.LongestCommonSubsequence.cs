

public interface ILongCommonSubsequence
{
    public int LongestCommonSubsequence(string text1, string text2);
}

public class LongCommonSubsequence : ILongCommonSubsequence
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var memo = new Dictionary<(int, int), int>();
        return LongestCommonSubsequenceAt(text1, text2, 0, 0, memo);
    }

    private int LongestCommonSubsequenceAt(string text1, string text2, int text1Index, int text2Index, Dictionary<(int,int),int> memo)
    {
        var memoKey = (text1Index, text2Index);
        if (memo.ContainsKey(memoKey))
            return memo[memoKey];
        var m = text1.Length;
        var n = text2.Length;

        if (text1Index >= m)
            return 0;

        if (text2Index >= n)
            return 0;

        if (text1[text1Index] == text2[text2Index])
        {
            var returnValue = 1 + LongestCommonSubsequenceAt(text1, text2, text1Index + 1, text2Index + 1, memo);
            memo[memoKey] = returnValue;
            return returnValue;
        }
            

        var leaveT1 = LongestCommonSubsequenceAt(text1, text2, text1Index, text2Index + 1, memo);
        var leaveT2 = LongestCommonSubsequenceAt(text1, text2, text1Index + 1, text2Index, memo);

        var max = Math.Max(leaveT1, leaveT2);
        memo[memoKey] = max;
        return max;
    }
}
