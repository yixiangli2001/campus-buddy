using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusBuddy.Models
{
    /// <summary>
    /// Base class for all items (Lost and Found, Events, etc.)
    /// Demo: Polymorphism, Properties, Virtual Methods
    /// </summary>
    public abstract class Item : IMatchable, ISearchable
    {
        // Properties - these store data about the item
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public string Location { get; set; }
        public DateTime DateReported { get; set; }
        public ItemStatus Status { get; set; }
        public string ReporterName { get; set; }
        public string ReporterContact { get; set; }
        public string ImagePath { get; set; }
        public List<string> Tags { get; set; }

        // Constructor - runs when you create a new Item
        protected Item()
        {
            Id = Guid.NewGuid().ToString(); // Creates unique ID
            DateReported = DateTime.Now;     // Sets current date/time
            Status = ItemStatus.Active;      // New items are active
            Tags = new List<string>();       // Empty list of tags
        }

        // Virtual method - child classes can override this
        public virtual string GetDisplayInfo()
        {
            return $"{Title} - {Category} at {Location}";
        }

        // Abstract method - child classes MUST implement this
        public abstract ItemType GetItemType();

        // IMatchable implementation - calculates how well two items match
        public virtual double CalculateMatchScore(IMatchable other)
        {
            if (other is not Item otherItem)
                return 0;

            double score = 0;

            // Category match (30 points)
            if (this.Category == otherItem.Category)
                score += 30;

            // Keyword overlap (40 points)
            var myKeywords = this.GetKeywords();
            var otherKeywords = otherItem.GetKeywords();
            var commonKeywords = myKeywords.Intersect(otherKeywords, StringComparer.OrdinalIgnoreCase).Count();

            if (myKeywords.Count > 0 && otherKeywords.Count > 0)
            {
                var keywordScore = (double)commonKeywords / Math.Max(myKeywords.Count, otherKeywords.Count);
                score += keywordScore * 40;
            }

            // Location similarity (20 points)
            if (!string.IsNullOrEmpty(this.Location) && !string.IsNullOrEmpty(otherItem.Location))
            {
                if (this.Location.Equals(otherItem.Location, StringComparison.OrdinalIgnoreCase))
                    score += 20;
                else if (this.Location.Contains(otherItem.Location, StringComparison.OrdinalIgnoreCase) ||
                         otherItem.Location.Contains(this.Location, StringComparison.OrdinalIgnoreCase))
                    score += 10;
            }

            // Date proximity (10 points)
            var daysDifference = Math.Abs((this.DateReported - otherItem.DateReported).Days);
            if (daysDifference <= 7)
                score += 10 * (1 - (daysDifference / 7.0));

            return Math.Round(score, 2);
        }

        // Gets keywords from title, description, and tags
        public virtual List<string> GetKeywords()
        {
            var keywords = new List<string>();

            // Extract words from title
            if (!string.IsNullOrEmpty(Title))
                keywords.AddRange(Title.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            // Extract words from description
            if (!string.IsNullOrEmpty(Description))
                keywords.AddRange(Description.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            // Add tags
            keywords.AddRange(Tags);

            // Clean and return unique keywords
            return keywords
                .Where(k => k.Length > 2) // Ignore very short words
                .Select(k => k.ToLower().Trim('.', ',', '!', '?'))
                .Distinct()
                .ToList();
        }

        // ISearchable implementation
        public virtual bool MatchesSearch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return true;

            var lowerSearchTerm = searchTerm.ToLower();
            var searchableText = GetSearchableText().ToLower();

            return searchableText.Contains(lowerSearchTerm);
        }

        public virtual string GetSearchableText()
        {
            return $"{Title} {Description} {Location} {Category} {string.Join(" ", Tags)}";
        }

        // Override ToString for debugging
        public override string ToString()
        {
            return GetDisplayInfo();
        }
    }

}
