
using System.Text;

public interface IMergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2);

}

public class MergeStringsAlternately : IMergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        var maxLength = Math.Max(word1.Length, word2.Length);

        var sb = new StringBuilder();
        for (int i = 0; i < maxLength; i++)
        {
            if (i < word1.Length)
                sb.Append(word1[i]);
            if (i < word2.Length)
                sb.Append(word2[i]);
        }

        return sb.ToString();
    }
}
