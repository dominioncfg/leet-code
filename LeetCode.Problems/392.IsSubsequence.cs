public interface IIsSubsequenceCalculator

{
    public bool IsSubsequence(string s, string t);
}

public class IsSubsequenceCalculator : IIsSubsequenceCalculator
{
    public bool IsSubsequence(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        for (int initialSlidingWindowIndex = 0; initialSlidingWindowIndex < t.Length; initialSlidingWindowIndex++)
        {
            var initialSlidingWindowChar = t[initialSlidingWindowIndex];
            var lookForIndex = 0;

            if (initialSlidingWindowChar != s[lookForIndex])
                continue;

            
            for (int matchIndex = initialSlidingWindowIndex; matchIndex < t.Length; matchIndex++)
            {
                var matchSlidingWindowChar = t[matchIndex];

                if (matchSlidingWindowChar != s[lookForIndex])
                    continue;

                if (lookForIndex == s.Length - 1)
                    return true;
                
                lookForIndex++;
            }

        }

        return false;
    }
}
