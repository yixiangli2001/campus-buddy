using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campus_buddy.Models;

namespace campus_buddy.Helpers
{
    /// <summary>
    /// Extension methods for Campus Buddy
    /// Demonstrates: Extension methods requirement
    /// </summary>
    
    public static class Extensions
    {
        //extension method to check if an item is older than specified days
        // usage: if (item.IsOlderThan(30)) { ... }
        public static bool IsRecent(this Item item)
        {
            return (DateTime.Now - item.DateReported).TotalDays <= 7;
        }

        // Extension method to check if an item is older than specified days
        public static bool IsOlderThan(this Item item, int days)
        {
            return (DateTime.Now - item.DateReported).TotalDays > days;
        }

        //extension method to get human-readable time since reported
        // usage: string time = item.GetTimeSinceReported();

        public static string GetTimeSinceReported(this Item item)
        {
            var timeSpan = DateTime.Now - item.DateReported;

            if (timeSpan.TotalMinutes < 1)
                return "Just now";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minutes ago";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hours ago";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} days ago";
            else if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)} weeks ago";
            else
                return $"{(int)(timeSpan.TotalDays / 30)} months ago";
        }

        // Extension method to filter items by category
        // usage: var electronics = items.FilterByCategory(ItemCategory.Electronics);
        public static IEnumerable<T> FilterByCategory<T>(this IEnumerable<T> items, ItemCategory category)
            where T : Item
        {
            return items.Where(item => item.Category == category);
        }

        // Extension method to filter items by status
        // Usage: var activeItems = items.FilterByStatus(ItemStatus.Active);

        public static IEnumerable<T> FilterByStatus<T>(this IEnumerable<T> items, ItemStatus status)
            where T : Item
        {
            return items.Where(item => item.Status == status);
        }

        // Extenstion method to get active items only
        // Usage: var active = items.GetActiveItems();

        public static IEnumerable<T> GetActiveItems<T>(this IEnumerable<T> items)
            where T : Item
        {
            return items.Where(item => item.Status == ItemStatus.Active);
        }

        // Extension method to search items by keyword
        // Usage: var results = items.SearchByKeyword("laptop");

        public static IEnumerable<T> SearchByKeyword<T>(this IEnumerable<T> items, string keyword)
            where T : Item
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(item => item.MatchesSearch(keyword));
        }

        // Extension method to sort items by date (newest first)
        // Usage: var sorted = items.SortByNewest();

        public static IEnumerable<T> SortByNewest<T>(this IEnumerable<T> items)
           where T : Item
        {
            return items.OrderByDescending(item => item.DateReported);
        }

        // Extension method to sort items by date (oldest first)
        // Usage: var sorted = items.SortByOldest();

        public static IEnumerable<T> SortByOldest<T>(this IEnumerable<T> items)
           where T : Item
        {
            return items.OrderBy(item => item.DateReported);
        }

        // Extension method to get items from a specific location
        // Usage: var libraryItems = items.FromLocation("Library");

        public static IEnumerable<T> FromLocation<T>(this IEnumerable<T> items, string location)
            where T : Item
        {
            if (string.IsNullOrWhiteSpace(location))
                return items;

            return items.Where(item =>
                item.Location != null &&
                item.Location.Contains(location, StringComparison.OrdinalIgnoreCase));
        }

        // Extension method using LINQ with Lambda expression (demonstrates requirement)
        // it will finds top matches for a given item
        // Usage: var matches = foundItems.FindTopMatches(lostItem, 5);

        public static IEnumerable<T> FindTopMatches<T>(this IEnumerable<T> items, Item targetItem, int topN = 10)
            where T : Item
        {
            return items
                .Select(item => new { Item = item, Score = item.CalculateMatchScore(targetItem) })
                .Where(x => x.Score > 0)
                .OrderByDescending(x => x.Score)
                .Take(topN)
                .Select(x => x.Item);
        }
    }
}
