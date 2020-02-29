using System;
using System.Collections.Generic;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyLastTests
    {
        public Employee JoeyLast(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException($"{nameof(employees)} is empty");

            var last = enumerator.Current;

            while (enumerator.MoveNext()) last = enumerator.Current;

            return last;

            //var enumerator = source.GetEnumerator();
            //enumerator.MoveNext()

            //Employee result=null;
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    if (current.LastName=="Chen")
            //    {
            //        result = current;
            //    }
            //}
            //if (result==null)
            //{
            //    throw new InvalidOperationException($"{nameof(source)} is empty");
            //}

            //return result;
        }

        public TSource JoeyLast<TSource>(List<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException($"{nameof(source)} is empty");

            var last = enumerator.Current;

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current)) last = current;
            }

            if (predicate(last)) return last ;

            throw new InvalidOperationException($"{nameof(source)} is empty");
        }

        [Test]
        public void get_last_chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"}
            };

            var employee = JoeyLast(employees, current => current.LastName == "Chen");

            new Employee {FirstName = "David", LastName = "Chen"}
                .ToExpectedObject().ShouldMatch(employee);
        }

        [Test]
        public void get_last_employee()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Cash", LastName = "Li"}
            };

            var employee = JoeyLast(employees);

            new Employee {FirstName = "Cash", LastName = "Li"}
                .ToExpectedObject().ShouldMatch(employee);
        }


        [Test]
        public void get_last_employee_when_no_girls()
        {
            var employees = new Employee[]
            {
            };

            TestDelegate action = () => JoeyLast(employees);
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}