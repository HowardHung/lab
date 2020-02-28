using System;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtension
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> products, Func<TSource, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var source in products)
                if (predicate(source))
                    result.Add(source);

            return result;
        }
    }
}