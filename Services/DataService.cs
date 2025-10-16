using campus_buddy.Data;
using campus_buddy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Services
{
    /// <summary>
    /// Service for saving and loading data to/from JSON files
    /// Demonstrates: File reading and writing (Assignment requirement)
    /// </summary>

    public class DataService
    {
        

        //file path
        private string dataDirectory;
        private string lostItemsFile;
        private string foundItemsFile;
        private string usersFile;
        private string notificationsFile;

        //Repositories
        public Repository<LostItem> LostItems { get; private set; }
        public Repository<FoundItem> FoundItems { get; private set; }
        public Repository<User> Users { get; private set; }
        public Repository<Notification> Notifications { get; private set; }

        //Current user
        public User? CurrentUser { get; private set; }
        public event EventHandler? CurrentUserChanged;


        // Singleton instance
        private static DataService instance;

        //get the singleton instance of DataService
        public static DataService Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new DataService();
                }
                return instance;
            }
        }


        // Private constructor for singleton
        private DataService()
        {
            // Set up data directory
            dataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CampusBuddy"
            );

            // Create directory if it doesn't exist
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            //set up file paths
            lostItemsFile = Path.Combine(dataDirectory, "lost_items.json");
            foundItemsFile = Path.Combine(dataDirectory, "found_items.json");
            usersFile = Path.Combine(dataDirectory, "users.json");
            notificationsFile = Path.Combine(dataDirectory, "notifications.json");

            // Initialize repositories
            LostItems = new Repository<LostItem>();
            FoundItems = new Repository<FoundItem>();
            Users = new Repository<User>();
            Notifications = new Repository<Notification>();

            //Load all existing data
            LoadAllData();

            //Create a default user if no users exist
            var user = Users.FindOne(u => true);

            if (user == null)
            {
                CurrentUser = new User("Demo User", "demo@student.uts.edu.au", "password", "250111111");
                Users.Add(CurrentUser);
                SaveAllData();
            }
        }

        //Saves all data to JSON files
        public void SaveAllData()
        {
            try
            {
                SaveToFile(lostItemsFile, LostItems.GetAll());
                SaveToFile(foundItemsFile, FoundItems.GetAll());
                SaveToFile(usersFile, Users.GetAll());
                SaveToFile(notificationsFile, Notifications.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving data: " + ex.Message);
            }
        }

        //Loads all data from JSON files
        public void LoadAllData()
        {
            try
            {
                // Clear existing data
                LostItems.Clear();
                FoundItems.Clear();
                Users.Clear();
                Notifications.Clear();
                // Load from files
                var lostItemsList = LoadFromFile<List<LostItem>>(lostItemsFile);
                if (lostItemsList != null)
                    LostItems.AddRange(lostItemsList);

                var foundItemsList = LoadFromFile<List<FoundItem>>(foundItemsFile);
                if (foundItemsList != null)
                    FoundItems.AddRange(foundItemsList);

                var usersList = LoadFromFile<List<User>>(usersFile);
                if (usersList != null)
                    Users.AddRange(usersList);

                var notificationsList = LoadFromFile<List<Notification>>(notificationsFile);
                if (notificationsList != null)
                    Notifications.AddRange(notificationsList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading data: " + ex.Message);
            }
        }

        //Save data to a JSON file
        private void SaveToFile<T>(string filePath, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        //Loads data from a JSON File
        private T LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        //Gets the current user 
        public User GetCurrentUser()
        {
            return CurrentUser;
        }

        public void SetCurrentUser(User? user)
        {
            CurrentUser = user;
            CurrentUserChanged?.Invoke(this, EventArgs.Empty);
        }

        //Adds a new user and saves
        public void AddUser(User user)
        {

                Users.Add(user);
                SaveAllData();
        }

        //Adds a lost item and saves
        public void AddLostItem(LostItem item)
        {
                LostItems.Add(item);
                SaveAllData();            
        }

        //Adds a found item and saves
        public void AddFoundItem(FoundItem item)
        {
                FoundItems.Add(item);
                SaveAllData();
        }

        //Updates an items status 
        public void UpdateItemStatus(string itemId, ItemStatus newStatuts)
        {
            //Try to find in lost items
            var lostItem = LostItems.FindOne(i => i.Id == itemId);
            if (lostItem != null)
            {
                lostItem.Status = newStatuts;
                SaveAllData();
                return;
            }

            //Try to find in found items
            var foundItem = FoundItems.FindOne(i => i.Id == itemId);
            if (foundItem != null)
            {
                foundItem.Status = newStatuts;
                SaveAllData();
                return;
            }
        }

        //Deletes an item 
        public bool DeleteItem(string itemId)
        {
            //Try lost items
            var lostItem = LostItems.FindOne(i => i.Id == itemId);
            if (lostItem != null)
            {
                LostItems.Remove(lostItem);
                SaveAllData();
                return true;
            }
            //Try found items
            var foundItem = FoundItems.FindOne(i => i.Id == itemId);
            if (foundItem != null)
            {
                FoundItems.Remove(foundItem);
                SaveAllData();
                return true;
            }
            return false;
        }

        //Gets data directory path
        public string GetDataDirectory()
        {
            return dataDirectory;
        }

        internal User UpdateUserDetails(User user, string name, string phone, string password)
        {
            user.Name = name;
            user.PhoneNumber = phone;
            user.Password = password;
            Users.Update(u => u.UserId == user.UserId, user);
            SaveAllData();
            return user;
        }
    }
}
