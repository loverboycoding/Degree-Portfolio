using NUnit.Framework;
using System.Numerics;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _player = new Player("John", "A brave adventurer");
            _item = new Item(new string[] { "sword", "weapon" }, "bronze sword", "a sharp bronze sword");
            _player.Inventory.Put(_item);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.AreEqual(_item, _player.Locate("sword"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(_player, _player.Locate("me"));
            Assert.AreEqual(_player, _player.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(_player.Locate("shield"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string actualDescription = _player.GetFullDescription();
            string expectedDescription = " You are John, a brave adventurer. You are holding\ta sharp bronze sword (sword)\n";

            // Temporarily print both actual and expected descriptions to compare visually
            Console.WriteLine("Actual: " + actualDescription);
            Console.WriteLine("Expected: " + expectedDescription);

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
