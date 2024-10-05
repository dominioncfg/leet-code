public interface ILongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s);
}

public class LongestSubstringWithoutRepeatingCharactersBasicSlidingWindow : ILongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        for (int startingIndex = 0; startingIndex < s.Length && maxLength < (s.Length - startingIndex + 1); startingIndex++)
        {
            var startingChar = s[startingIndex];
            var differentChars = new HashSet<char>([startingChar]);
            var currentSubstringMaxLength = 1;

            for (int endIndex = startingIndex + 1; endIndex < s.Length; endIndex++)
            {
                char currentChar = s[endIndex];
                bool isUnique = differentChars.Add(currentChar);

                if (!isUnique)
                    break;

                currentSubstringMaxLength++;
            }

            if (currentSubstringMaxLength > maxLength)
                maxLength = currentSubstringMaxLength;
        }

        return maxLength;
    }
}





public class LongestSubstringWithoutRepeatingCharactersMovingSlidingWindow : ILongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        int startingIndex = 0;
        var differentChars = new HashSet<char>();

        for (int endIndex = startingIndex; endIndex < s.Length; endIndex++)
        {
            char startingChar = s[startingIndex];
            char currentChar = s[endIndex];

            bool isRepeated = differentChars.Contains(currentChar);
            if (isRepeated)
            {
                do
                {
                    startingChar = s[startingIndex];
                    differentChars.Remove(startingChar);
                    startingIndex++;
                } while (startingIndex < s.Length && startingChar != currentChar);
            }
            differentChars.Add(currentChar);

            var currentSubstringMaxLength = endIndex - startingIndex + 1;
            maxLength = Math.Max(maxLength, currentSubstringMaxLength);
        }

        return maxLength;
    }
}

public class LongestSubstringWithoutRepeatingCharactersMovingSlidingDictionaryWindow : ILongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        int startingIndex = 0;
        var differentChars = new Dictionary<char, int>();

        for (int endIndex = startingIndex; endIndex < s.Length; endIndex++)
        {
            char currentChar = s[endIndex];

            if (differentChars.ContainsKey(currentChar) && differentChars[currentChar] >= startingIndex)
            {
                startingIndex = differentChars[currentChar] + 1;
            }

            differentChars[currentChar] = endIndex;

            var currentSubstringMaxLength = endIndex - startingIndex + 1;
            if (currentSubstringMaxLength > maxLength)
                maxLength = currentSubstringMaxLength;

        }
        
        return maxLength;
    }
}