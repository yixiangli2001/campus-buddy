using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_buddy.Data
{
    // Generic repository pattern for managing collections 
    // Demonstrates: Generic based Collection
    /// >typeparam name="T">The type of entity in the repository.</typeparam>

    public class Repository<T> where T : class
    {
        //Private collection to store items
        private List<T> items;

        //Constructor
        public Repository()
        {
            items = new List<T>();
        }

        //Add an item to the repo
        public void Add(T item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        //Add mulitple items to the repo
        public void AddRange(IEnumerable<T> newItems)
        {
             if (newItems != null)
            {
                items.AddRange(newItems);
            }
        }

        //Removes an item from the repo
        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        //gets all items from the repo
        public List<T> GetAll()
        {
            return new List<T>(items);
        }

        //Find items based on a predicate
        public List<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate).ToList();
        }

        //Finds a single item based on a predicate
        public T FindOne(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }

        //get the count of items in the repo
        public int Count()
        {
            return items.Count;
        }

        //Clear all items from the repo
        public void Clear()
        {
            items.Clear();
        }

        //check if any items match the predicate
        public bool Any(Func<T, bool> predicate)
        {
            return items.Any(predicate);
        }

        //update an existing item 
        public bool Update(Func<T, bool> predicate, T updatedItem)
        { 
            var index = items.FindIndex(item => predicate(item));
            if (index >= 0)
            {
                items[index] = updatedItem;
                return true;
            }
            return false;
        }
    }
}
