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

        public Employee JoeyLast(IEnumerable<Employee> employees, Func<Employee, bool> predicate)
        {
            var enumerator = employees.GetEnumerator();
            var hasMatch = false;
            Employee employee = null;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    hasMatch = true;
                    employee = current;
                }
            }

            return hasMatch ? employee : throw new InvalidOperationException();
        }

        [Test]
        public void get_null_when_employee_is_empty()
        {
            var employees = new List<Employee>();

            var actual = JoeyLastOrDefault(employees);
            Assert.IsNull(actual);
        }

        private Tsource JoeyLastOrDefault<Tsource>(IEnumerable<Tsource> employees)
        {
            var enumerator = employees.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return default(Tsource);
            }

            var last = enumerator.Current;
            while (enumerator.MoveNext())
            {
                last=enumerator.Current;
            }

            return last;

            //Employee employee = null;
            //var enumerator = employees.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    employee = current;
            //}

            //return employee;
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