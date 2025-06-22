using MiNET.Utils.Skins;
using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        
        public Player(string name, string description) : base(new string[] { "me", "inventory" }, name, description)
        {
            _inventory = new Inventory(); 
        }

        public override string GetFullDescription()
        {

            return $"You are {Name}, {ShortDescription}. You are holding " + _inventory.ItemList;
        }


        public GameObject Locate(string id)
        {
            if (AreYou(id)) 
            {
                return this;  
            }
            return _inventory.Fetch(id);  
        }

        
        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
