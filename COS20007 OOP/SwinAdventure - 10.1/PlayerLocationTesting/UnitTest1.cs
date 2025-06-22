using NUnit.Framework;
using System.Numerics;
using SwinAdventure;
namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;
        private Location _location;
        private Item _inventoryItem;
        private Item _locationItem;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Hero", "A brave adventurer.");
            _location = new Location(new string[] { "forest" }, "Dark Forest", "A spooky dark forest.");
            _inventoryItem = new Item(new string[] { "sword" }, "Sword", "A sharp blade.");
            _locationItem = new Item(new string[] { "shield" }, "Shield", "A sturdy shield.");

            _player.Inventory.Put(_inventoryItem);
            _location.Inventory.Put(_locationItem);
            _player.Location = _location;
        }

        [Test]
        public void PlayerCanLocateItself()
        {
            Assert.AreEqual(_player, _player.Locate("inventory"));
        }

        [Test]
        public void PlayerCanLocateItemInInventory()
        {
            Assert.AreEqual(_inventoryItem, _player.Locate("sword"));
        }

        [Test]
        public void PlayerCanLocateItemInLocation()
        {
            Assert.AreEqual(_locationItem, _player.Locate("shield"));
        }

        [Test]
        public void PlayerCannotLocateNonexistentItem()
        {
            Assert.IsNull(_player.Locate("potion"));
        }
    }
}
