using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusBuddy.Models
{
    /// <summary>
    /// Represents a notification sent to a user
    /// </summary>
    public class Notification
    {
        // Properties
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }
        public NotificationPriority Priority { get; set; }
        public string RelatedItemId { get; set; }
        public double MatchScore { get; set; }

        // Default constructor
        public Notification()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            IsRead = false;
            Priority = NotificationPriority.Medium;
        }

        // Constructor overloading
        public Notification(string userId, string title, string message) : this()
        {
            UserId = userId;
            Title = title;
            Message = message;
        }

        // Factory method to create a notification when a match is found
        public static Notification CreateMatchNotification(string userId, Item lostItem, Item foundItem, double matchScore)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = "Potential Match Found!",
                Message = $"A {foundItem.Category} matching your lost item '{lostItem.Title}' " +
                         $"has been found at {foundItem.Location}. Match score: {matchScore:F0}%",
                RelatedItemId = foundItem.Id,
                MatchScore = matchScore,
                Priority = matchScore >= 70 ? NotificationPriority.High : NotificationPriority.Medium
            };

            return notification;
        }

        //Factory method to create a notification when item status changes
        public static Notification CreateStatusNotification(string userId, string itemTitle, ItemStatus newStatus)
        {
            return new Notification
            {
                UserId = userId,
                Title = "Item Status Updated",
                Message = $"Your item '{itemTitle}' status has been changed to {newStatus}",
                Priority = NotificationPriority.Low
            };
        }

        // Helper method to get human-readable time since notification was created
        public string GetTimeAgo()
        {
            var timeSpan = DateTime.Now - CreatedDate;

            if (timeSpan.TotalMinutes < 1)
                return "Just now";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minutes ago";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hours ago";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} days ago";
            else
                return CreatedDate.ToString("MMM dd, yyyy");
        }

        public override string ToString()
        {
            return $"[{Priority}] {Title} - {GetTimeAgo()}";
        }
    }
    
}
