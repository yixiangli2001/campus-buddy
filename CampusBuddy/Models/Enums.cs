using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusBuddy.Models
{

    /// <summary>
    /// Represents the category of an item
    /// </summary>
    
    public enum ItemCategory 
    {
        Electronics,
        Books,
        Accessories,
        Cards,
        Clothing,
        Keys,
        Other
    }

    /// <summary>
    /// Represents the current status of an item post
    /// </summary>
    public enum ItemStatus 
    {
        Active,
        Resolved,
        Expired
    }

    /// <summary>
    /// Represents whether an item is lost or found
    /// </summary>
    public enum ItemType 
    {
        Lost,
        Found
    }

    /// <summary>
    /// Represents the priority level of a notification
    /// </summary>
    public enum  NotificationPriority
    {
        Low,
        Medium,
        High
    }
}
