using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCup.Domain.AggregateModels.Geo;

namespace WorldCup.Infrastructure.Database.Mapping
{
    internal class CountryMapping : EntityMapping<Country, int>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.ISOCode).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        }
    }
}
