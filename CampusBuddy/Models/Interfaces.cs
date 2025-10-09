using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusBuddy.Models
{
    /// <summary>
    /// Interface for items that can be matched
    /// </summary>
    public interface IMatchable
    {
        //Calculate match score between 2 items

        /// <param name="other">The other item to compare with</param>
        /// <returns>Match score betweem 0 and 100 </returns>
        
        double CalculateMatchScore(IMatchable other);
    

   
    /// Gets keywords from the item for matching
    //Return list of keywords 
        List<string> GetKeywords();
    }

    /// <summary>
    /// Interface for entities that can receive notifications
    /// </summary>
    public interface  INotifiable
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
