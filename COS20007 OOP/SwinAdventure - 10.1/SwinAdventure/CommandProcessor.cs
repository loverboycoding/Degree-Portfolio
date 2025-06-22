using System.Collections.Generic;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new MoveCommand(),
                new LookCommand(),
                
            };
        }
        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }


        public string ExecuteCommand(Player player, string[] text)
        {
            if (text.Length == 0)
                return "No command provided.";

            string commandId = text[0].ToLower();

            foreach (Command command in _commands)
            {
                if (command.AreYou(commandId))
                {
                    return command.Execute(player, text);
                }
            }

            return $"I don't know how to {commandId}.";
        }
    }
}
