using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusBuddy.Models
{
    /// <summary>
    /// Represents a found item reported by a student
    /// Demonstrates: Inheritance from Item base class
    /// </summary>
    public class FoundItem : Item
    {
        // Additional properties specific to found items
        public DateTime DateFound { get; set; }
        public string CurrentLocation { get; set; } // Where the item is being held
        public bool HandedToSecurity { get; set; }

        // Default constructor
        public FoundItem() : base()
        {
            DateFound = DateTime.Now;
            HandedToSecurity = false;
        }

        // Constructor overloading
        public FoundItem(string title, ItemCategory category, string location) : this()
        {
            Title = title;
            Category = category;
            Location = location;
            CurrentLocation = location;
        }

        // Must implement abstract method
        public override ItemType GetItemType()
        {
            return ItemType.Found;
        }

        // Override display method
        public override string GetDisplayInfo()
        {
            var securityTag = HandedToSecurity ? "[At Security Office] " : "";
            var locationInfo = !string.IsNullOrEmpty(CurrentLocation)
                ? $" - Currently at: {CurrentLocation}"
                : "";

            return $"{securityTag}FOUND: {Title} - {Category} at {Location}{locationInfo}";
        }

        // Additional method specific to FoundItem
        public void HandToSecurity()
        {
            HandedToSecurity = true;
            CurrentLocation = "Security Office";
        }
    }
   

}
