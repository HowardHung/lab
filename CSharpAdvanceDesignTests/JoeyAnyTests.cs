﻿using System;
using System.Collections.Generic;
using Lab;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    //[Ignore("not yet")]
    public class JoeyAnyTests
    {
        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = emptyEmployees.JoeyAny();
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

            var actual = emptyEmployees.JoeyAny();
            Assert.IsTrue(actual);
        }

        [Test]
        public void any_number_greater_than_91()
        {
            var numbers = new[] {87, 88, 91, 93, 0};
            var actual = numbers.JoeyAny(current => current>91);
            Assert.IsTrue(actual);
        }
    }
}