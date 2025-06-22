using SwinAdventure;

public class LookCommand : Command
{
    public LookCommand() : base(new string[] { "look" }) { }

    public override string Execute(Player player, string[] text)
    {
        if (text.Length == 1 && text[0].ToLower() == "inventory")
        {
            // Return the player's inventory item list
            return $"You are carrying:\n{player.Inventory.ItemList}";
        }
        // Error if the input is not in the correct format
        if (text.Length != 3 && text.Length != 5)
        {
            return "I don't know how to look like that";
        }

        if (text[0] != "look")
        {
            return "Error in look input";
        }

        if (text[1] != "at")
        {
            return "What do you want to look at?";
        }

        string itemId = text[2];
        IHaveInventory container;

        // Handle "look at item in container"
        if (text.Length == 5)
        {
            if (text[3] != "in")
            {
                return "What do you want to look in?";
            }

            string containerId = text[4];
            container = FetchContainer(player, containerId);

            // Container not found
            if (container == null)
            {
                return $"I cannot find the {containerId}.";
            }
        }
        else
        {
            // If no container specified, use player inventory
            container = player;
        }

        // Try to locate the item in the container
        GameObject item = container.Locate(itemId);

        if (item == null)
        {
            return $"I cannot find the {itemId} in the {container.Name}.";
        }

        // Return full description of the located item
        return item.GetFullDescription();
    }

    // Fetch the container (like a bag) where the player is looking
    private IHaveInventory FetchContainer(Player player, string containerId)
    {
        return player.Locate(containerId) as IHaveInventory;
    }
}
