using NUnit.Framework;
using campus_buddy.Models;
using campus_buddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace campus_buddy.Tests
{
    [TestFixture]
    public class ExtensionMethodsTests
    {
        private List<LostItem> testItems;

        [SetUp]
        public void Setup()
        {
            testItems = new List<LostItem>
            {
                new LostItem
                {
                    Title = "Old Laptop",
                    Category = ItemCategory.Electronics,
                    DateReported = DateTime.Now.AddDays(-10),
                    Status = ItemStatus.Active
                },
                new LostItem
                {
                    Title = "New Phone",
                    Category = ItemCategory.Electronics,
                    DateReported = DateTime.Now.AddDays(-2),
                    Status = ItemStatus.Active
                },
                new LostItem
                {
                    Title = "Resolved Item",
                    Category = ItemCategory.Books,
                    DateReported = DateTime.Now.AddDays(-5),
                    Status = ItemStatus.Resolved
                },
                new LostItem
                {
                    Title = "Recent Backpack",
                    Category = ItemCategory.Accessories,
                    DateReported = DateTime.Now.AddDays(-1),
                    Status = ItemStatus.Active
                }
            };
        }

        [Test]
        public void IsRecent_WithRecentItem_ReturnsTrue()
        {
            var recentItem = new LostItem
            {
                DateReported = DateTime.Now.AddDays(-3)
            };

            bool result = recentItem.IsRecent();

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsRecent_WithOldItem_ReturnsFalse()
        {
            var oldItem = new LostItem
            {
                DateReported = DateTime.Now.AddDays(-10)
            };

            bool result = oldItem.IsRecent();

            Assert.That(result, Is.False);
        }

        [Test]
        public void FilterByCategory_ReturnsOnlyMatchingCategory()
        {
            var electronics = testItems.FilterByCategory(ItemCategory.Electronics).ToList();

            Assert.That(electronics.Count, Is.EqualTo(2));
            Assert.That(electronics.All(i => i.Category == ItemCategory.Electronics), Is.True);
        }

        [Test]
        public void GetActiveItems_ReturnsOnlyActiveItems()
        {
            var activeItems = testItems.GetActiveItems().ToList();

            Assert.That(activeItems.Count, Is.EqualTo(3));
            Assert.That(activeItems.All(i => i.Status == ItemStatus.Active), Is.True);
        }

        [Test]
        public void SortByNewest_ReturnsSortedByDateDescending()
        {
            var sorted = testItems.SortByNewest().ToList();

            Assert.That(sorted[0].Title, Is.EqualTo("Recent Backpack"));
            Assert.That(sorted[sorted.Count - 1].Title, Is.EqualTo("Old Laptop"));
        }

        [Test]
        public void SearchByKeyword_FindsMatchingItems()
        {
            var results = testItems.SearchByKeyword("Laptop").ToList();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0].Title, Does.Contain("Laptop"));
        }

        [Test]
        public void ChainMultipleExtensions_WorksCorrectly()
        {
            var result = testItems
                .GetActiveItems()
                .FilterByCategory(ItemCategory.Electronics)
                .SortByNewest()
                .ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(i => i.Status == ItemStatus.Active), Is.True);
            Assert.That(result.All(i => i.Category == ItemCategory.Electronics), Is.True);
        }
    }
}
