using NUnit.Framework;
using campus_buddy.Models;
using campus_buddy.Services;
using System;
using System.Linq;

namespace campus_buddy.Tests
{
    /// <summary>
    /// Tests for the MatchingService class
    /// Demonstrates: NUnit testing requirement
    /// </summary>
    [TestFixture]
    public class MatchingServiceTests
    {
        private MatchingService matchingService;
        private DataService dataService;

        [SetUp]
        public void Setup()
        {
            dataService = DataService.Instance;
            matchingService = new MatchingService();

            dataService.LostItems.Clear();
            dataService.FoundItems.Clear();
        }

        [Test]
        public void CalculateMatchScore_ExactMatch_ReturnsHighScore()
        {
            var lostItem = new LostItem
            {
                Title = "Black Laptop",
                Category = ItemCategory.Electronics,
                Location = "Library",
                Description = "MacBook Pro 13 inch"
            };

            var foundItem = new FoundItem
            {
                Title = "Black Laptop",
                Category = ItemCategory.Electronics,
                Location = "Library",
                Description = "MacBook Pro 13 inch"
            };

            double score = lostItem.CalculateMatchScore(foundItem);

            Assert.That(score, Is.GreaterThan(70));
            Assert.That(score, Is.LessThanOrEqualTo(100));
        }

        [Test]
        public void CalculateMatchScore_DifferentCategory_ReturnsLowerScore()
        {
            var lostItem = new LostItem
            {
                Title = "Laptop",
                Category = ItemCategory.Electronics,
                Location = "Library",
                Description = "Black laptop"
            };

            var foundItem = new FoundItem
            {
                Title = "Laptop",
                Category = ItemCategory.Books,
                Location = "Library",
                Description = "Black laptop"
            };

            double score = lostItem.CalculateMatchScore(foundItem);

            Assert.That(score, Is.LessThanOrEqualTo(70));
        }

        [Test]
        public void CalculateMatchScore_SameLocation_IncreasesScore()
        {
            var lostItem = new LostItem
            {
                Title = "Keys",
                Category = ItemCategory.Keys,
                Location = "Building 11",
                Description = "Car keys"
            };

            var foundItem1 = new FoundItem
            {
                Title = "Keys",
                Category = ItemCategory.Keys,
                Location = "Building 11",
                Description = "Keys"
            };

            var foundItem2 = new FoundItem
            {
                Title = "Keys",
                Category = ItemCategory.Keys,
                Location = "Building 7",
                Description = "Keys"
            };

            double scoreWithSameLocation = lostItem.CalculateMatchScore(foundItem1);
            double scoreWithDifferentLocation = lostItem.CalculateMatchScore(foundItem2);

            Assert.That(scoreWithSameLocation, Is.GreaterThan(scoreWithDifferentLocation));
        }

        [Test]
        public void FindMatchesForLostItem_ReturnsMatchesAboveThreshold()
        {
            var lostItem = new LostItem
            {
                Title = "Red Backpack",
                Category = ItemCategory.Accessories,
                Location = "Gym",
                Description = "Red backpack with laptop"
            };

            dataService.AddLostItem(lostItem);

            var highMatch = new FoundItem
            {
                Title = "Red Backpack",
                Category = ItemCategory.Accessories,
                Location = "Gym",
                Description = "Backpack with laptop"
            };

            var lowMatch = new FoundItem
            {
                Title = "Blue Bag",
                Category = ItemCategory.Clothing,
                Location = "Building 5",
                Description = "Blue sports bag"
            };

            dataService.AddFoundItem(highMatch);
            dataService.AddFoundItem(lowMatch);

            var matches = matchingService.FindMatchesForLostItem(lostItem, 10);

            Assert.That(matches, Is.Not.Empty);
            Assert.That(matches.All(m => m.MatchScore >= 30), Is.True);
        }

        [Test]
        public void FindMatchesForLostItem_WithNoMatches_ReturnsEmptyList()
        {
            var lostItem = new LostItem
            {
                Title = "Unique Item",
                Category = ItemCategory.Other,
                Location = "Nowhere",
                Description = "Very specific unique item"
            };

            dataService.AddLostItem(lostItem);

            var foundItem = new FoundItem
            {
                Title = "Different Item",
                Category = ItemCategory.Electronics,
                Location = "Somewhere",
                Description = "Nothing in common"
            };

            dataService.AddFoundItem(foundItem);

            var matches = matchingService.FindMatchesForLostItem(lostItem, 10);

            Assert.That(matches, Is.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            dataService.LostItems.Clear();
            dataService.FoundItems.Clear();
        }
    }
}
