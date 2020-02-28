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
    }
}