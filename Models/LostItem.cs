using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Models
{
    /// <summary>
    /// Represents a lost item reported by a student
    /// Demonstrates: Inheritance from Item base class
    /// </summary>
    public class LostItem : Item
    {
        // Additional properties specific to lost items
        public DateTime DateLost { get; set; }
        public string RewardOffered { get; set; }
        public bool IsUrgent { get; set; }

        // Default constructor
        public LostItem() : base()
        {
            DateLost = DateTime.Now;
            IsUrgent = false;
        }

        // Constructor overloading - demonstrates polymorphism
        public LostItem(string title, ItemCategory category, string location) : this()
        {
            Title = title;
            Category = category;
            Location = location;
        }

        // Must implement abstract method from base class
        public override ItemType GetItemType()
        {
            return ItemType.Lost;
        }

        // Override virtual method to customize display
        public override string GetDisplayInfo()
        {
            var urgentTag = IsUrgent ? "[URGENT] " : "";
            var rewardTag = !string.IsNullOrEmpty(RewardOffered) ? $" [Reward: {RewardOffered}]" : "";
            return $"{urgentTag}LOST: {Title} - {Category} at {Location}{rewardTag}";
        }

        // Override matching to boost urgent items
        public override double CalculateMatchScore(IMatchable other)
        {
            var baseScore = base.CalculateMatchScore(other);

            // Boost score if this is urgent
            if (IsUrgent)
                baseScore = Math.Min(100, baseScore * 1.1);

            return baseScore;
        }
    }
}
