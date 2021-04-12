using System.Linq;
using System.Linq.Expressions;

namespace Chocolate.Business.Helpers
{
    //from https://www.tabsoverspaces.com/229310-sorting-in-iqueryable-using-string-as-column-name/?utm_source=blog.cincura.net
    public static class OrderHelper
    {
        //Extension method for ordering.
        //We need to create a generic lambda expression for the column that will be ordered.
        public static IOrderedQueryable<T> OrderingHelper<T>(this IQueryable<T> source,
            string propertyName, bool descending)
        {
            //we create the parameter of the lambda expression. We get the x => from x => x...
            var parameter = Expression.Parameter(typeof(T), string.Empty);

            //we get the property on which we will sort. We get the x.Name for example
            var property = Expression.PropertyOrField(parameter, propertyName);

            //we create the lambda expression
            var sort = Expression.Lambda(property, parameter);

            //we create the final call for the lambda expression and add the ordering.
            //this will create OrderBy(x => x.something)
            var call = Expression.Call(
                typeof(Queryable),
                $"OrderBy{(descending ? "Descending" : string.Empty)}",
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));

            //IOrderedQueryable is returned because it has ordering now
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
    }
}
