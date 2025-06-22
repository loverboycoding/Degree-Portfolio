using MiNET.Utils.Skins;
using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string description) : base(new string[] { "me", "inventory" }, name, description)
        {
            _inventory = new Inventory(); 
        }

        public override string GetFullDescription()
        {

            return $"You are {Name}, {ShortDescription}. You are holding " + _inventory.ItemList;
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;

            GameObject item = Inventory.Fetch(id);
            if (item != null) return item;

            return _location?.Locate(id);
        }

        
        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
