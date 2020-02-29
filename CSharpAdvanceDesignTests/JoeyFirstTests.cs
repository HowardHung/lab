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
        private Girl JoeyFirst(IEnumerable<Girl> girls)
        {
            var enumerator = girls.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
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
    }
}