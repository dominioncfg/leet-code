using System.Text;

public interface ILongestCommonPrefixCalculator
{
    public string LongestCommonPrefix(string[] strs);
}

public class LongestCommonPrefixCalculator : ILongestCommonPrefixCalculator
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1) return strs[0];
        StringBuilder ret = new StringBuilder("", strs[0].Length);
        for (int i = 0; i < strs[0].Length; i++)
        {
            char c = strs[0][i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (!(i < strs[j].Length) || c != strs[j][i]) return ret.ToString();
            }
            ret.Append(c);
        }
        return ret.ToString();
    }
}
