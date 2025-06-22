namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look", "inventory" }) { }

        public override string Execute(Player player, string[] text)
        {
            // Case 1: "inventory" to display player's inventory
            if (text.Length == 1 && text[0].ToLower() == "inventory")
            {
                return player.Inventory.ItemList.Length > 0
                    ? $"You are carrying:\n{player.Inventory.ItemList}"
                    : "You are carrying nothing.";
            }

            // Case 2: "look" command to describe the current location
            if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return $"{player.Location.GetFullDescription()}\n\n{player.Location.AvailablePaths()}";
            }

            // Case 3: "look around"
            if (text.Length == 2 && text[0].ToLower() == "look" && text[1].ToLower() == "around")
            {
                return $"{player.Location.GetFullDescription()}\n\n{player.Location.AvailablePaths()}";
            }


            // Case 4: "look at inventory in <location>"
            if (text.Length == 5 && text[0].ToLower() == "look" && text[1].ToLower() == "at"
                && text[2].ToLower() == "inventory" && text[3].ToLower() == "in")
            {
                string locationId = text[4].ToLower();
                IHaveInventory location = FetchContainer(player, locationId);

                if (location == null)
                {
                    return $"I cannot find the {locationId}.";
                }

                if (location is Location loc)
                {
                    return loc.Inventory.ItemList.Length > 0
                        ? $"The {loc.Name} contains:\n{loc.Inventory.ItemList}"
                        : $"The {loc.Name} is empty.";
                }

                return $"The {location.Name} does not contain an inventory.";
            }

            // Case 5: "look at <item>" or "look at <item> in <container>"
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0].ToLower() != "look" || text[1].ToLower() != "at")
                {
                    return "Error in look input.";
                }

                string itemId = text[2].ToLower();
                IHaveInventory container;

                if (text.Length == 5)
                {
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in?";
                    }

                    string containerId = text[4].ToLower();
                    container = FetchContainer(player, containerId);

                    if (container == null)
                    {
                        return $"I cannot find the {containerId}.";
                    }
                }
                else
                {
                    container = player; // Default to player's inventory
                }

                GameObject item = container.Locate(itemId);

                if (item == null)
                {
                    return $"I cannot find the {itemId} in the {container.Name}.";
                }

                return item.GetFullDescription();
            }

            // Case 6: "look at me"
            if (text.Length == 3 && text[0].ToLower() == "look" && text[1].ToLower() == "at" && text[2].ToLower() == "me")
            {
                return player.GetFullDescription();
            }

            return "I don't understand what you want to do.";
        }

        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            // Search for the container in the player's location or inventory
            return player.Locate(containerId) as IHaveInventory ?? player.Location?.Locate(containerId) as IHaveInventory;
        }
    }
}
