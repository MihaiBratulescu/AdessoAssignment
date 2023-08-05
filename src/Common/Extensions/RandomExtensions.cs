namespace System.Collections.Generic
{
    public static class RandomExtensions
    {
        public static T OneOf<T>(this Random random, T[] list)
        {
            int randomIndex = random.Next(list.Length - 1);

            return list.ElementAt(randomIndex);
        }

        public static IEnumerable<T> Randomize<T>(this Random random, params T[] items)
        {
            var copy = items.ToArray();
            int count = copy.Length;

            while (count > 0)
            {
                int index = random.Next(0, --count);
                yield return copy[index];
                copy[index] = copy[count];
            }
        }
    }
}
