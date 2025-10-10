using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Models
{
    /// <summary>
    /// Interface for items that can be matched with other items
    /// </summary>
    public interface IMatchable
    {
        double CalculateMatchScore(IMatchable other);
        List<string> GetKeywords();
    }

    /// <summary>
    /// Interface for entities that can receive notifications
    /// </summary>
    public interface INotifiable
    {
        void SendNotification(Notification notification);
        List<Notification> GetNotifications();
    }

    /// <summary>
    /// Interface for items that can be searched
    /// </summary>
    public interface ISearchable
    {
        bool MatchesSearch(string searchTerm);
        string GetSearchableText();
    }
}
