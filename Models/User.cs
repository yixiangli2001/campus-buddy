using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Models
{
    /// <summary>
    /// Represents a user of the Campus Buddy system
    /// Demonstrates: INotifiable interface implementation
    /// </summary>
    public class User : INotifiable
    {
        // Properties
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredDate { get; set; }

        // Private collections
        private List<Notification> notifications;
        private List<string> postedItemIds;

        // Default constructor
        public User()
        {
            UserId = Guid.NewGuid().ToString();
            RegisteredDate = DateTime.Now;
            notifications = new List<Notification>();
            postedItemIds = new List<string>();
        }

        // Constructor overloading
        public User(string name, string email, string password, string phone) : this()
        {
            Name = name;
            Email = email;
            PhoneNumber = phone;
            Password = password;
        }

        // INotifiable implementation - REQUIRED by interface
        public void SendNotification(Notification notification)
        {
            if (notification != null)
            {
                notifications.Add(notification);
                notification.IsRead = false;
            }
        }

        public List<Notification> GetNotifications()
        {
            return new List<Notification>(notifications);
        }

        // Additional helper methods
        public List<Notification> GetUnreadNotifications()
        {
            return notifications.Where(n => !n.IsRead).ToList();
        }

        public int GetUnreadCount()
        {
            return notifications.Count(n => !n.IsRead);
        }

        public void MarkNotificationAsRead(string notificationId)
        {
            var notification = notifications.Find(n => n.Id == notificationId);
            if (notification != null)
                notification.IsRead = true;
        }

        public void MarkAllAsRead()
        {
            notifications.ForEach(n => n.IsRead = true);
        }

        public void AddPostedItem(string itemId)
        {
            if (!postedItemIds.Contains(itemId))
                postedItemIds.Add(itemId);
        }

        public List<string> GetPostedItemIds()
        {
            return new List<string>(postedItemIds);
        }

        public override string ToString()
        {
            return $"{Name} ({Email})";
        }
    }
}
