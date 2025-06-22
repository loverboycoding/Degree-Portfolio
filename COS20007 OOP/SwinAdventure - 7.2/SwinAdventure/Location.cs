namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public GameObject Locate(string id)
        {
            // Check if the location itself is being looked for
            if (AreYou(id))
            {
                return this;
            }

            // Check if the item is in the location's inventory
            return _inventory.Fetch(id);
        }

        public override string GetFullDescription()
        {
            return $"{Name}: {ShortDescription}";
        }
    }
}
