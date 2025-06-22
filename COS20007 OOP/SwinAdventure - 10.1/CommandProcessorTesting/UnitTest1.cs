using NUnit.Framework;
using System.Numerics;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor _commandProcessor;
        private Player _player;
        private Location _startLocation;

        [SetUp]
        public void Setup()
        {
            _startLocation = new Location(new string[] { "start" }, "Starting Location", "The start of your adventure.");
            _player = new Player("Adventurer", "A brave explorer");
            _player.Location = _startLocation;
            _commandProcessor = new CommandProcessor();
        }

        [Test]
        public void TestExecuteMoveCommand()
        {
            _startLocation.AddPath(new Path(Path.Direction.North, new Location(new string[] { "north" }, "North Location", "You are north.")));
            string result = _commandProcessor.ExecuteCommand(_player, new string[] { "move", "north" });
            Assert.AreEqual("You move north to the North Location.", result);
        }

        [Test]
        public void TestUnknownCommand()
        {
            string result = _commandProcessor.ExecuteCommand(_player, new string[] { "fly", "upward" });
            Assert.AreEqual("I don't know how to fly.", result);
        }

        [Test]
        public void TestIncompleteCommand()
        {
            string result = _commandProcessor.ExecuteCommand(_player, new string[] { "move" });
            Assert.AreEqual("Where do you want to go?", result);
        }

        [Test]
        public void TestExecuteLookCommand()
        {
            _player.Inventory.Put(new Item(new string[] { "gem" }, "a shiny gem", "It's a very shiny gem."));
            string result = _commandProcessor.ExecuteCommand(_player, new string[] { "look", "at", "gem" });
            Assert.AreEqual("a shiny gem: It's a very shiny gem.", result);
        }
    }
}
