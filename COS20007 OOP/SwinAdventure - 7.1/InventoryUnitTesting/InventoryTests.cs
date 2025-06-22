using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private Inventory _inventory;
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _item = new Item(new string[] { "sword", "weapon" }, "bronze sword", "a sharp bronze sword");
            _inventory.Put(_item);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void TestNoFindItem()
        {
            Assert.IsFalse(_inventory.HasItem("shield"));
        }

        [Test]
        public void TestFetchItem()
        {
            Item fetchedItem = _inventory.Fetch("sword");
            Assert.AreEqual(_item, fetchedItem);
            Assert.IsTrue(_inventory.HasItem("sword"));  // Fetch should not remove the item
        }

        [Test]
        public void TestTakeItem()
        {
            Item takenItem = _inventory.Take("sword");
            Assert.AreEqual(_item, takenItem);
            Assert.IsFalse(_inventory.HasItem("sword"));  // Item should be removed
        }

        [Test]
        public void TestItemList()
        {
            string expectedList = "\ta sharp bronze sword (sword)\n";
            Assert.AreEqual(expectedList, _inventory.ItemList);
        }
    }
}
