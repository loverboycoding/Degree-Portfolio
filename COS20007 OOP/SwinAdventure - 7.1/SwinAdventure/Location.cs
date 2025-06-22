using MiNET.Utils.Skins;
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private List<Item> _items;

        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
        }

        public Item RemoveItem(string id)
        {
            Item item = Locate(id) as Item;
            if (item != null)
            {
                _items.Remove(item);
            }
            return item;
        }

        public GameObject Locate(string id)
        {
            // Check if the location itself matches the id
            if (AreYou(id)) return this;

            // Check if the location has the item
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item item in _items)
                {
                    itemList += $"\t{item.ShortDescription}\n";
                }
                return itemList;
            }
        }

        public override string GetFullDescription()
        {
            return $"{Name}\n{ShortDescription}\nItems in location:\n{ItemList}";
        }
    }
}
