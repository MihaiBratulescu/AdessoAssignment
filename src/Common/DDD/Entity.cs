namespace Common
{
    public abstract class Entity<TKey> where TKey : notnull
    {
        public TKey ID { get; protected set; }

#pragma warning disable CS8618
        protected Entity() { }
#pragma warning restore CS8618
        protected Entity(TKey ID) => this.ID = ID;

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TKey> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetUnproxiedType(this) != GetUnproxiedType(other))
                return false;

            if (ID == null || ID.Equals(default(TKey)))
                return false;

            return ID.Equals(other.ID);
        }

        public static bool operator ==(Entity<TKey>? a, Entity<TKey>? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TKey>? a, Entity<TKey>? b) => !(a == b);

        public override int GetHashCode() => (GetUnproxiedType(this).ToString() + ID).GetHashCode();

        private static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            //const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();

            return type.ToString().Contains(EFCoreProxyPrefix)
                ? type.BaseType ?? type
                : type;
        }
    }
}