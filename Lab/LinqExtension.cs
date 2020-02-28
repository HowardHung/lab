using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtension
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> products, Func<TSource, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var source in products)
                if (predicate(source))
                    result.Add(source);

            return result;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> sources,
            Func<TSource, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (var source in sources) result.Add(selector(source));

            return result;
        }
    }
}