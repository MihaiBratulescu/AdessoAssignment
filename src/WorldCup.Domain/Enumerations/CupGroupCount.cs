namespace WorldCup.Domain.Enumerations
{
    public enum CupGroupCount
    {
        Four = 4,
        Eight = 8
    }

    public static class CupGroupCountExtensions
    {
        public static FootballGroups[] GetGroups(this CupGroupCount count)
        {
            return count switch
            {
                CupGroupCount.Four => Enum.GetValues<FootballGroups>().Take(4).ToArray(),
                CupGroupCount.Eight => Enum.GetValues<FootballGroups>().Take(8).ToArray(),
                _ => throw new ArgumentException($"FootballGroups '{count}' is not supported."),
            };
        }
    }
}
