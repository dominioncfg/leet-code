
using System.Collections.Generic;

public interface ILetterCombinationsOfAPhoneNumber
{
    public IList<string> LetterCombinations(string digits);
}

public class LetterCombinationsOfAPhoneNumber : ILetterCombinationsOfAPhoneNumber
{
    private static readonly Dictionary<char, char[]> Telephones = new()
    {
         { '2', ['a','b','c'] },
         { '3', ['d','e','f'] },
         { '4', ['g','h','i'] },
         { '5', ['j','k','l'] },
         { '6', ['m','n','o'] },
         { '7', ['p','q','r', 's'] },
         { '8', ['t','u','v'] },
         { '9', ['w','x','y','z'] },
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
            return [];

        var converted = new List<List<char>>(digits.Length);


        foreach (var c in digits)
        {
            converted.Add(new List<char>(Telephones[c]));
        }


        var res = new HashSet<string>();

        BackTrack(converted, res, []);

        return [.. res];
    }

    private void BackTrack(List<List<char>> chars, HashSet<string> res, List<char> sol, int currentListIndex = 0)
    {
        if (currentListIndex >= chars.Count)
        {
            res.Add(new string([.. sol]));
            return;
        }


        for (int i = 0; i < chars[currentListIndex].Count; i++)
        {
            sol.Add(chars[currentListIndex][i]);
            BackTrack(chars, res, sol, currentListIndex + 1);
            sol.RemoveAt(sol.Count - 1);
        }
    }
}


