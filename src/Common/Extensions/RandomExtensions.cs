namespace System.Collections.Generic
{
    public static class RandomExtensions
    {
        public static T OneOf<T>(this Random random, T[] list)
        {
            int randomIndex = random.Next(list.Length - 1);

            return list.ElementAt(randomIndex);
        }
    }
}
