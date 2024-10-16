public interface ILongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k);
}

public class LongestRepeatingCharacterReplacement : ILongestRepeatingCharacterReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        var maxLength = 0;

        var l = 0;
        var frecuencies = new int[26];

        for (int r = 0; r < s.Length; r++)
        {
            var newCharToInvestigate = s[r];
            frecuencies[newCharToInvestigate - 'A']++;

            var max = frecuencies.Max();
            while (r - l + 1 - max > k)
            {
                frecuencies[s[l] - 'A']--;
                l++;
            }

            maxLength = Math.Max(maxLength, r - l + 1);
        }
        return maxLength;
    }
}
