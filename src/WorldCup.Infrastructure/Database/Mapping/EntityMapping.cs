using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WorldCup.Infrastructure.Database.Mapping
{
    public abstract class EntityMapping<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var entityName = typeof(TEntity).Name;
            var tableName = EntityMapping<TEntity, TKey>.AddTableSuffix(entityName);
            var primaryKeyName = $"{typeof(TEntity).Name}Id";

            builder.ToTable(tableName);

            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .HasColumnName(primaryKeyName);
        }

        private static string AddTableSuffix(string name)
        {
            return name.EndsWith('y')
                ? name.TrimEnd('y') + "ies"
                : $"{name}s";
        }
    }
}
