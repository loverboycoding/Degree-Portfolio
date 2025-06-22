namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Dictionary<string, Path> _paths;
        public Location(string[] ids, string name, string description) : base(ids, name, description)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Path>();
        }

        public Inventory Inventory => _inventory;
        public void AddPath(Path path)
        {
            _paths[path.direction.ToString().ToLower()] = path;
        }

        // Method to retrieve a Path based on direction
        public Path GetPath(string direction)
        {
            _paths.TryGetValue(direction.ToLower(), out Path path);
            return path;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public string AvailablePaths()
        {
            if (_paths.Count == 0)
            {
                return "There are no paths from here.";
            }

            string pathList = "You see paths leading to:\n";
            foreach (var path in _paths.Values)
            {
                pathList += $"- Move {path.direction} to {path.Destination.Name}.\n";
            }
            return pathList.TrimEnd();
        }

    }
}
