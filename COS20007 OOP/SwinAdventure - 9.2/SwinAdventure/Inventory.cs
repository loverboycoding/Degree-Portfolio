using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void Put(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            _items.Add(item);
            Console.WriteLine($"Item '{item.Name}' added to inventory.");
        }

        public Item Take(string id)
        {
            Item itemToTake = Fetch(id);
            if (itemToTake != null)
            {
                _items.Remove(itemToTake);
            }
            return itemToTake;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item item in _items)
                {
                    itemList += $"\t{item.ShortDescription} ({item.FirstId})\n";
                }
                return itemList;
            }
        }
    }
}
