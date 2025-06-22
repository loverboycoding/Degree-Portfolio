using NUnit.Framework;
using System.Numerics;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LookCommandTests
    {
        private Player _player;
        private Location _location;
        private Item _inventoryItem;
        private Item _locationItem;
        private LookCommand _lookCommand;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Hero", "A brave adventurer.");
            _location = new Location(new string[] { "cave" }, "Dark Cave", "A spooky dark cave.");
            _inventoryItem = new Item(new string[] { "sword" }, "Sword", "A sharp blade.");
            _locationItem = new Item(new string[] { "shield" }, "Shield", "A sturdy shield.");

            _player.Inventory.Put(_inventoryItem);
            _location.Inventory.Put(_locationItem);
            _player.Location = _location;

            _lookCommand = new LookCommand();
        }

        [Test]
        public void LookAtItemInInventory()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "sword" });
            Assert.AreEqual("Sword: A sharp blade.", result);
        }

        [Test]
        public void LookAtItemInLocation()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "shield" });
            Assert.AreEqual("Shield: A sturdy shield.", result);
        }

        [Test]
        public void LookAroundLocation()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "around" });
            Assert.AreEqual("Dark Cave: A spooky dark cave.", result);
        }

        [Test]
        public void LookAtNonexistentItem()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "potion" });
            Assert.AreEqual("I cannot find the potion in the Hero", result);
        }

        [Test]
        public void LookInNonexistentLocation()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "in", "lake" });
            Assert.AreEqual("I don't understand what you want to do.", result);
        }
    }
}
