public interface IJewelsAndStones
{
    public int NumJewelsInStones(string jewels, string stones);
}

public class JewelsInStones : IJewelsAndStones
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var fastLookupOfJewels = new HashSet<char>();
        foreach (var j in jewels)
        {
            fastLookupOfJewels.Add(j);
        }

        var total = 0;
        foreach (var j in stones)
        {
            if (jewels.Contains(j))
                total++;
        }


        return total;
    }
}
