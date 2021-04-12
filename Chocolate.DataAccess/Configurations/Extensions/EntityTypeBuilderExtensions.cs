using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Chocolate.DataAccess.Configurations.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        //extension method -- it creates constraints for enums
        public static EntityTypeBuilder<TEntity> HasEnumCheckConstraint<TEntity, TEnum>(
            this EntityTypeBuilder<TEntity> entityTypeBuilder,
            //the following code is for an expression x => x.status
            //it is a delegate!
            Expression<Func<TEntity, TEnum>> propertyExpression)
            where TEntity : class
        {
            //Checks if the inserted type is enum because this method works only with enums
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException(
                    $"Type '{typeof(TEnum).FullName}' is not an enumeration.");
            }

            //converts enum to an IEnumerable<byte>
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => Convert.ToByte(e));

            //get the name of the table that contains the enum
            var table = typeof(TEntity).Name;

            //get the name of the column. This is the enum column
            var column = ((MemberExpression)propertyExpression.Body)
                .Member.Name;

            //Creates the constraint that will be created in the database after the migration
            return entityTypeBuilder.HasCheckConstraint(
                $"cc_{table}_{column}",
                $"{column} IN ({string.Join(',', values)})");
        }
    }
}
