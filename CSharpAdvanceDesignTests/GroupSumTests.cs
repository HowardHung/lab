﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class GroupSumTests
    {
        private IEnumerable<int> JoeyGroupSum(IEnumerable<Account> accounts, int pageSize, Func<Account, int> selector)
        {
            var list = accounts.ToList();
            var pageIndex = 0;
            while (pageIndex*pageSize<list.Count())
            {
                
                yield return list.JoeySkip(pageIndex * pageSize).JoeyTake(pageSize).Sum(selector);
                pageIndex++;
            }
        }

        [Test]
        public void group_sum_of_saving()
        {
            var accounts = new[]
            {
                new Account {Name = "Joey", Saving = 10},
                new Account {Name = "David", Saving = 20},
                new Account {Name = "Tom", Saving = 30},
                new Account {Name = "Joseph", Saving = 40},
                new Account {Name = "Jackson", Saving = 50},
                new Account {Name = "Terry", Saving = 60},
                new Account {Name = "Mary", Saving = 70},
                new Account {Name = "Peter", Saving = 80},
                new Account {Name = "Jerry", Saving = 90},
                new Account {Name = "Martin", Saving = 100},
                new Account {Name = "Bruce", Saving = 110}
            };

            //sum of all Saving of each group which 3 Account per group
            //var actual = accounts.MyGroupSum(current => current.Saving, 3);
            var actual = JoeyGroupSum(accounts, 3, x => x.Saving);

            var expected = new[] {60, 150, 240, 210};

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }

    public class Account
    {
        public int Saving { get; set; }
        public string Name { get; set; }
    }
}