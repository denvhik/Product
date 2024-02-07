using System.Linq.Expressions;
using TestApp.Infrostructures.DataTable;

namespace TestApp.Infrostructures.Extensions
{
    public static class DTParametersExtensions
    {
        public static List<SortCriteria> GetSortCriterias(this DTParameterModel parameters)
        {
            if (parameters == null || parameters.Order == null || !parameters.Order.Any())
            {
                return null;
            }

            return parameters.Order.Select(i =>
                new SortCriteria
                {
                    Column = parameters.Columns[i.Column].Data,
                    Direction = i.Dir
                })
                .ToList();
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, List<SortCriteria> sortCriterias)
        {
            // no sort criterias - return original query.
            if (sortCriterias == null || !sortCriterias.Any())
            {
                return query;
            }

            // order by multiple parameters is done using following code: query.OrderBy(...).ThenBy(...).ThenBy(...)
            // so, for the first sort rule we use the orderby or orderbydescending methods
            var firstCriteria = sortCriterias.First();
            var orderByMethodName = string.Format("OrderBy{0}",
                firstCriteria.Direction.ToLower() == "asc" ? "" : "descending");

            var result = CallOrderBy(query, orderByMethodName, firstCriteria, "p0");
            if (sortCriterias.Count() > 1)
            {
                // for the rest sort criterias, we use ThenBy or ThenByDescending methods
                for (int i = 1; i < sortCriterias.Count(); i++)
                {
                    var criteria = sortCriterias[i];
                    orderByMethodName = string.Format("ThenBy{0}",
                        criteria.Direction.ToLower() == "asc" ? "" : "descending");

                    result = CallOrderBy(result, orderByMethodName, criteria, string.Format("p{0}", i));
                }
            }
            return result;
        }

        private static IQueryable<T> CallOrderBy<T>(IQueryable<T> query, string orderByMethodName, SortCriteria criteria, string parameterName)
        {
            ParameterExpression parameter = Expression.Parameter(query.ElementType, parameterName);

            MemberExpression memberAccess = null;
            foreach (var property in criteria?.Column?.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }

            LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);

            MethodCallExpression result = Expression.Call(
                      typeof(Queryable),
                      orderByMethodName,
                      new[] { query.ElementType, memberAccess.Type },
                      query.Expression,
                      Expression.Quote(orderByLambda));

            return query.Provider.CreateQuery<T>(result);
        }
    }
}
