using System;
using System.Collections.Generic;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    //[Ignore("not yet")]
    public class JoeyAnyTests
    {
        private bool JoeyAny(IEnumerable<Employee> employees)
        {
            return employees.GetEnumerator().MoveNext();
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsFalse(actual);
        }

        [Test]
        public void three_employees()
        {
            var emptyEmployees = new[]
            {
                new Employee(),
                new Employee(),
                new Employee()
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsTrue(actual);
        }
    }
}