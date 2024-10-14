

public interface IKokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h);
}

public class KokoEatingBananas : IKokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var max = GetMax(piles);

        var l = 1;
        var r = max;

        while (l < r)
        {
            var middle = (l + r) / 2;
            bool isASolution = CanEatXBananasInHours(piles, h, middle);

            if (isASolution)
            {
                r = middle;
            }
            else
            {
                l = middle + 1;
            }

        }

        return l;
    }

    private static int GetMax(int[] piles)
    {
        var max = int.MinValue;

        foreach (var p in piles)
        {
            if (max < p)
                max = p;
        }

        return max;
    }


    private bool CanEatXBananasInHours(int[] piles, int availableHours, int numberOfBananasPerHour)
    {
        foreach (var pile in piles)
        {
            var hours = Math.Ceiling(pile / (double)numberOfBananasPerHour);
            availableHours -= (int)hours;
            if (availableHours < 0)
                return false;

        }

        return true;
    }
}
