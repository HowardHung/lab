using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    //[Ignore("not yet")]
    public class JoeyFirstTests
    {
        private TSource JoeyFirst<TSource>(IEnumerable<TSource> girls)
        {
            var enumerator = girls.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
            throw new InvalidOperationException($"{nameof(girls)} id empty");
        }

        [Test]
        public void get_first_girl()
        {
            var girls = new[]
            {
                new Girl {Age = 10},
                new Girl {Age = 20},
                new Girl {Age = 30}
            };

            var girl = JoeyFirst(girls);
            var expected = new Girl {Age = 10};

            expected.ToExpectedObject().ShouldEqual(girl);
        }

        [Test]
        public void get_first_girl_when_no_girls()
        {
            var girls = new Girl[]
            {
            };

            TestDelegate action = () => JoeyFirst(girls);
            Assert.Throws<InvalidOperationException>(action);
        }
        [Test]
        public void get_first_chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var employee = JoeyFirstWithCondition(employees, current => current.LastName=="Chen");
            new Employee() { FirstName = "Joey", LastName = "Chen" }.ToExpectedObject().ShouldMatch(employee);
        }

        private TSource JoeyFirstWithCondition<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return current;
                }
            }
            throw new InvalidOperationException($"{nameof(source)} id empty");
            
        }
    }
}