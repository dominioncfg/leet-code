
public interface IMaximumNumberOfBalloons
{
    public int MaxNumberOfBalloons(string text);
}

public class MaximumNumberOfBalloons : IMaximumNumberOfBalloons
{
    const string lookForWord = "balloon";

    public int MaxNumberOfBalloons(string text)
    {
        var histogram = BuildHistogramOfRelevantCharacters(lookForWord, text);

        var fullWordAppereances = 0;
        while (true)
        {
            for (var currentCharIndex = 0; currentCharIndex < lookForWord.Length; currentCharIndex++)
            {
                var currentChar = lookForWord[currentCharIndex];

                if (!histogram.ContainsKey(currentChar))
                    return fullWordAppereances;

                if (histogram[currentChar] == 0)
                    return fullWordAppereances;

                histogram[currentChar]--;

            }
            fullWordAppereances++;
        }
    }

    private Dictionary<char, int> BuildHistogramOfRelevantCharacters(string lookForWord, string text)
    {
        var result = new Dictionary<char, int>(lookForWord.Length);

        foreach (var c in lookForWord)
        {
            result.TryAdd(c, 0);
        }

        foreach (var c in text)
        {
            if (result.ContainsKey(c))
                result[c]++;
        }

        return result;
    }
}
