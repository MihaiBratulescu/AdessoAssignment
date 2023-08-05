namespace System.Collections.Generic
{
    public static class RandomExtensions
    {
        public static T OneOf<T>(this Random random, IEnumerable<T> list)
        {
            int randomIndex = random.Next(list.Count() - 1);

            return list.ElementAt(randomIndex);
        }
    }
}
