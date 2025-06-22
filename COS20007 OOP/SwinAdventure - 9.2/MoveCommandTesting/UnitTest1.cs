using System.Numerics;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        private Player _player;
        private Location _startLocation;
        private Location _northLocation;
        private Path _northPath;
        private MoveCommand _moveCommand;

        [SetUp]
        public void Setup()
        {
            _startLocation = new Location(new string[] { "start" }, "Starting Location", "The starting point.");
            _northLocation = new Location(new string[] { "north" }, "North Location", "The north point.");
            _northPath = new Path(Path.Direction.North, _northLocation);
            _startLocation.AddPath(_northPath);

            _player = new Player("Hero", "The player character");
            _player.Location = _startLocation;
            _moveCommand = new MoveCommand();
        }

        [Test]
        public void TestPlayerMovesNorth()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.AreEqual("You move north to the North Location.", result);
            Assert.AreEqual(_northLocation, _player.Location);
        }

        [Test]
        public void TestPlayerInvalidDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "south" });
            Assert.AreEqual("You can't go that way.", result);
            Assert.AreEqual(_startLocation, _player.Location);
        }

        [Test]
        public void TestInvalidCommandFormat()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move" });
            Assert.AreEqual("Where do you want to go?", result);
        }
    }
}
