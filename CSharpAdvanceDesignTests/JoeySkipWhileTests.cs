using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    //[Ignore("not yet")]
    public class JoeySkipWhileTests
    {
        private readonly GroupSumTests _groupSumTests = new GroupSumTests();

        private IEnumerable<Card> JoeySkipWhile(IEnumerable<Card> cards, Func<Card, bool> predicate)
        {
            var enumerator = cards.GetEnumerator();
            var isStartTaking = false;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current) || isStartTaking)
                {
                    isStartTaking = true;
                    yield return current;
                }
            }

        }

        [Test]
        public void skip_cards_type_is_normal()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate}
            };

            var actual = JoeySkipWhile(cards, current => current.Kind == CardKind.Normal);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate}
            };

            expected.ToExpectedObject().ShouldMatch(actual.ToList());
        }
    }
}