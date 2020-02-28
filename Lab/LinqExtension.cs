using System;
using System.Collections;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtension
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }

            }
        }


        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
               yield return selector(enumerator.Current);
            }
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predict)
        {
            var result = new List<TSource>();
            var index = 0;
            foreach (var item in source)
            {
                if (predict(item, index))
                {
                    result.Add(item);
                }

                index++;
            }

            return result;


        }

        public static IEnumerable<TSource> JoeySelect<TSource>(this IEnumerable<TSource> source, Func<TSource, int, TSource> predict)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return (predict(enumerator.Current, index));
                index++;
            }

        }

        public static IEnumerable<TSource> JoeyTake<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index < count)
                {
                    yield return current;
                }
                else
                {
                    yield break;
                }

                index++;
            }
        }

        public static IEnumerable<Employee> JoeySkip(this IEnumerable<Employee> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index>=count)
                {
                    yield return enumerator.Current;
                }

                index++;

            }
        }

        public static IEnumerable<int> MyGroupSum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> currentSaving, int count)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            var sum = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (count > index++)
                {
                    sum += currentSaving(current);
                }
                else
                {
                    yield return sum;
                    sum = 0;
                    index = 0;
                }
            }
        }
    }
}