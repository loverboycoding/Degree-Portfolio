using System;
using SwinAdventure;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Get the player's name and description from the user.
        Console.Write("Enter your player's name: ");
        string playerName = Console.ReadLine();

        Console.Write("Enter a description for your player: ");
        string playerDescription = Console.ReadLine();

        // Create a Player object with the user's input.
        Player player = new Player(playerName, playerDescription);
        Console.WriteLine($"\nWelcome {playerName}, {playerDescription}!\n");

        // Step 2: Create two items and add them to the player's inventory.
        Item sword = new Item(new string[] { "sword" }, "a sword", "A sharp, shining sword.");
        Item shield = new Item(new string[] { "shield" }, "a shield", "A sturdy wooden shield.");

        player.Inventory.Put(sword);
        player.Inventory.Put(shield);
        Console.WriteLine("Items 'sword' and 'shield' have been added to your inventory.\n");

        // Step 3: Create a bag and add it to the player's inventory.
        Bag smallBag = new Bag(new string[] { "bag", "small bag" }, "a small bag", "A small leather bag.");
        player.Inventory.Put(smallBag);
        Console.WriteLine("A small bag has been added to your inventory.\n");

        // Step 4: Create another item and add it to the bag.
        Item gem = new Item(new string[] { "gem" }, "a gem", "A shiny, valuable gem.");
        smallBag.Inventory.Put(gem);
        Console.WriteLine("Item 'gem' has been placed inside the small bag.\n");

        // Create the LookCommand object.
        LookCommand lookCommand = new LookCommand();

        // Step 5: Loop reading commands from the user and getting the look command to execute them.
        while (true)
        {
            Console.WriteLine("\nEnter a command (or type 'exit' to quit):");
            string command = Console.ReadLine();

            if (command.ToLower() == "exit")
            {
                break; // Exit the loop and end the program.
            }

            // Split the command into an array of words.
            string[] commandWords = command.Split(' ');

            // Execute the LookCommand with the player and the user's input.
            string result = lookCommand.Execute(player, commandWords);
            Console.WriteLine(result);
        }

        Console.WriteLine("Goodbye!");
    }
}
