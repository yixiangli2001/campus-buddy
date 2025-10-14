using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using campus_buddy.Models;
using campus_buddy.Helpers;

namespace campus_buddy.Services
{
    /// <summary>
    /// Service for matching lost and found items
    /// This is a core feature of Campus Buddy
    /// </summary>
    public class MatchingService
    {
        private DataService dataService;
        private double minimumMatchThreshold = 30.0; // Minimum score to be considered a match

        // Constructor
        public MatchingService()
        {
            dataService = DataService.Instance;
        }

        /// <summary>
        /// Finds potential matches for a lost item among found items
        /// Demonstrates: LINQ with Lambda expressions
        /// </summary>
        public List<MatchResult> FindMatchesForLostItem(LostItem lostItem, int maxResults = 10)
        {
            // Get all active found items
            var foundItems = dataService.FoundItems
                .GetAll()
                .Where(f => f.Status == ItemStatus.Active)
                .ToList();

            // Calculate match scores using LINQ and Lambda
            var matches = foundItems
                .Select(foundItem => new MatchResult
                {
                    LostItem = lostItem,
                    FoundItem = foundItem,
                    MatchScore = lostItem.CalculateMatchScore(foundItem)
                })
                .Where(m => m.MatchScore >= minimumMatchThreshold) // Filter by threshold
                .OrderByDescending(m => m.MatchScore)              // Sort by best match
                .Take(maxResults)                                  // Limit results
                .ToList();

            return matches;
        }

        /// <summary>
        /// Finds potential matches for a found item among lost items
        /// </summary>
        public List<MatchResult> FindMatchesForFoundItem(FoundItem foundItem, int maxResults = 10)
        {
            // Get all active lost items
            var lostItems = dataService.LostItems
                .GetAll()
                .Where(l => l.Status == ItemStatus.Active)
                .ToList();

            // Calculate match scores
            var matches = lostItems
                .Select(lostItem => new MatchResult
                {
                    LostItem = lostItem,
                    FoundItem = foundItem,
                    MatchScore = foundItem.CalculateMatchScore(lostItem)
                })
                .Where(m => m.MatchScore >= minimumMatchThreshold)
                .OrderByDescending(m => m.MatchScore)
                .Take(maxResults)
                .ToList();

            return matches;
        }

        /// <summary>
        /// Automatically checks for matches when a new item is posted
        /// and creates notifications for potential matches
        /// </summary>
        public void CheckAndNotifyMatches(Item newItem)
        {
            List<MatchResult> matches = new List<MatchResult>();

            if (newItem is LostItem lostItem)
            {
                // Find matches for the lost item
                matches = FindMatchesForLostItem(lostItem, 5);

                // Create notification for the person who lost the item
                if (matches.Any())
                {
                    var user = dataService.GetCurrentUser();
                    var bestMatch = matches.First();

                    var notification = Notification.CreateMatchNotification(
                        user.UserId,
                        lostItem,
                        bestMatch.FoundItem,
                        bestMatch.MatchScore
                    );

                    user.SendNotification(notification);
                    dataService.Notifications.Add(notification);
                    dataService.SaveAllData();
                }
            }
            else if (newItem is FoundItem foundItem)
            {
                // Find matches for the found item
                matches = FindMatchesForFoundItem(foundItem, 5);

                // Create notification for the person who found the item
                if (matches.Any())
                {
                    var user = dataService.GetCurrentUser();
                    var bestMatch = matches.First();

                    var notification = Notification.CreateMatchNotification(
                        user.UserId,
                        bestMatch.LostItem,
                        foundItem,
                        bestMatch.MatchScore
                    );

                    user.SendNotification(notification);
                    dataService.Notifications.Add(notification);
                    dataService.SaveAllData();
                }
            }
        }

        /// <summary>
        /// Gets all matches above a certain threshold
        /// </summary>
        public List<MatchResult> GetAllMatches(double minScore = 50.0)
        {
            var allMatches = new List<MatchResult>();

            var lostItems = dataService.LostItems.GetAll().GetActiveItems();
            var foundItems = dataService.FoundItems.GetAll().GetActiveItems();

            foreach (var lostItem in lostItems)
            {
                foreach (var foundItem in foundItems)
                {
                    var score = lostItem.CalculateMatchScore(foundItem);

                    if (score >= minScore)
                    {
                        allMatches.Add(new MatchResult
                        {
                            LostItem = lostItem,
                            FoundItem = foundItem,
                            MatchScore = score
                        });
                    }
                }
            }

            return allMatches.OrderByDescending(m => m.MatchScore).ToList();
        }

        /// <summary>
        /// Sets the minimum match threshold
        /// </summary>
        public void SetMinimumThreshold(double threshold)
        {
            if (threshold >= 0 && threshold <= 100)
            {
                minimumMatchThreshold = threshold;
            }
        }

        /// <summary>
        /// Gets the current minimum threshold
        /// </summary>
        public double GetMinimumThreshold()
        {
            return minimumMatchThreshold;
        }
    }

    /// <summary>
    /// Represents a match between a lost and found item
    /// </summary>
    public class MatchResult
    {
        public LostItem LostItem { get; set; }
        public FoundItem FoundItem { get; set; }
        public double MatchScore { get; set; }

        /// <summary>
        /// Gets a color code based on match score
        /// </summary>
        public string GetMatchQuality()
        {
            if (MatchScore >= 80)
                return "Excellent Match";
            else if (MatchScore >= 60)
                return "Good Match";
            else if (MatchScore >= 40)
                return "Possible Match";
            else
                return "Weak Match";
        }

        public override string ToString()
        {
            return $"{GetMatchQuality()} ({MatchScore:F1}%): '{LostItem.Title}' ↔ '{FoundItem.Title}'";
        }
    }

}
