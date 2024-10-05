
public interface IValidAnagram
{
    public bool IsAnagram(string s, string t);
}

public class ValidAnagram : IValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length!= t.Length)
            return false;

        var tHistogram = new Dictionary<char,int>(t.Length);
        
        foreach(char c in t)
        {
            if (tHistogram.ContainsKey(c))
                tHistogram[c]++;
            else
                tHistogram[c] = 1;
        }

        foreach (char c in s)
        {
            if(!tHistogram.ContainsKey(c)|| tHistogram[c]==0)
                return false;
            tHistogram[c]--;
        }

        return true;
    }
}
