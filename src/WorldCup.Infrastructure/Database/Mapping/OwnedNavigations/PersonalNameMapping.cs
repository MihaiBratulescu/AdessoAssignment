using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using WorldCup.Domain.ValueObjects;

namespace WorldCup.Infrastructure.Database.Mapping.OwnedNavigations
{
    internal static class PersonalNameOwnedNavigationExtensions
    {
        public static void ConfigurePersonalName<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, PersonalName?>> selector)
            where T : class
        {
            builder.OwnsOne(selector, c =>
            {
                c.HasOne<T>().WithOne(selector);

                c.Property(c => c.Name)
                    .HasColumnName("Name");

                c.Property(c => c.Surname)
                    .HasColumnName("Surname");
            });
        }
    }
}
