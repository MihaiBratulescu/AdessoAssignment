namespace Common
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
        where TKey : notnull
    {
    }
}