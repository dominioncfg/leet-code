public interface IPermutationInString
{
    public bool CheckInclusion(string s1, string s2);
}

public class PermutationInString : IPermutationInString
{

    public bool CheckInclusion(string s1, string s2)
    {
        var expectedLenght = s1.Length;
        var l = 0;

        var lookForChars = GetCharsHistogram(s1);

        for (int r = 0; r < s2.Length; r++)
        {
            var currentChar = s2[r];
            if (!lookForChars.ContainsKey(currentChar))
            {
                while (l<r)
                {
                    lookForChars[s2[l]]++;
                    l++;
                }
                //lookForChars = GetCharsHistogram(s1);
                l++;
            }
            else 
            {
                if (lookForChars[currentChar] == 0)
                {
                    while (lookForChars[currentChar] == 0)
                    {
                        lookForChars[s2[l]]++;
                        l++;
                    }
                }

                lookForChars[currentChar]--;
            }
            
           
            var currentWindowLength = r - l + 1;
            if (currentWindowLength == expectedLenght)
                return true;

        }


        return false;
    }

    private static Dictionary<char, int> GetCharsHistogram(string s1)
    {
        var lookForChars = new Dictionary<char, int>();
        foreach (var s in s1)
        {
            if (lookForChars.ContainsKey(s))
            {
                lookForChars[s]++;
            }
            else
            {
                lookForChars[s] = 1;
            }
        }
        return lookForChars;
    }
}
