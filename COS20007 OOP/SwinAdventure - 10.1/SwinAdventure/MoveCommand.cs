namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) { }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length != 2)
            {
                return "Where do you want to go?";
            }

            string directionString = text[1];
            Path path = player.Location?.GetPath(directionString);

            if (path == null)
            {
                return "You can't go that way.";
            }

            player.Location = path.Destination;


            // Show the current location description and paths
            return $"You move {directionString} to the {path.Destination.Name}.\n\n" +
                   $"{path.Destination.GetFullDescription()}\n\n" +
                   $"{path.Destination.AvailablePaths()}";
        }
    }
}
