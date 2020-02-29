using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtension
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return JoeyWhere(source, (x, i) => predicate(x));
            //var enumerator = source.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    if (predicate(enumerator.Current))
            //    {
            //        yield return enumerator.Current;
            //    }
            //}
            //////////////////////////////
            //var result = new List<TSource>();
            //foreach (var item in source)
            //    if (predicate(item))
            //        result.Add(item);

            //return result;

            

        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predict)
        {
            var result = new List<TSource>();
            var index = 0;
            foreach (var item in source)
            {
                if (predict(item, index)) result.Add(item);

                index++;
            }

            return result;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            return JoeySelect(source, (x, i) => selector(x));
            //var enumerator = source.GetEnumerator();
            //while (enumerator.MoveNext()) yield return selector(enumerator.Current);
        }


        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predict)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return predict(enumerator.Current, index);
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
                    yield return current;
                else
                    yield break;

                index++;
            }
        }

        public static IEnumerable<TSource> JoeySkip<TSource>(this IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= count) yield return enumerator.Current;

                index++;
            }
        }

        public static IEnumerable<int> MyGroupSum<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int> wantAdd, int pageSize)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            var sum = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (pageSize > index++)
                {
                    sum += wantAdd(current);
                }
                else
                {
                    yield return sum;
                    sum = 0;
                    index = 0;
                }
            }
        }

        public static bool JoeyAll<TSource>(this IEnumerable<TSource> girls, Func<TSource, bool> predicate)
        {
            var enumerator = girls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current))
                    return false;
            }

            return true;
        }

        public static bool JoeyAny(this IEnumerable<Employee> employees)
        {
            return employees.GetEnumerator().MoveNext();
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> numbers, Func<TSource, bool> predicate)
        {
            var enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current)) return true;
            }

            return false;
        }
    }
}