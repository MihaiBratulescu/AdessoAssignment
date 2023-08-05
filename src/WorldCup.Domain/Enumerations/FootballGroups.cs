namespace WorldCup.Domain.Enumerations
{
    public enum FootballGroups
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
    }

    public static class FootballGroupsExtensions
    {
        public static char GetLetter(this FootballGroups group)
        {
            return group.ToString()[0];
        }
    }
}
