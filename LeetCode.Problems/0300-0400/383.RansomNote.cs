public interface IRansomNote
{
    public bool CanConstruct(string ransomNote, string magazine);
}

public class RansomNote : IRansomNote
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var histogram = new Dictionary<char, int>();
        foreach (var theChar in magazine)
        {
            if (histogram.ContainsKey(theChar))
                histogram[theChar]++;
            else
                histogram.Add(theChar, 1);
        }


        foreach (var theChar in ransomNote)
        {
            if (!histogram.ContainsKey(theChar)|| histogram[theChar] <=0)
                return false;
            else
                histogram[theChar]--;
        }
        return true;
    }
}
