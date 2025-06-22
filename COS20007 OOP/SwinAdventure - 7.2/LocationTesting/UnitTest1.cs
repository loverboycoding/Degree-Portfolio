using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LocationTests
    {
        private Location _location;
        private Item _item;

        [SetUp]
        public void SetUp()
        {
            _location = new Location(new string[] { "cave" }, "Dark Cave", "A dimly lit cave.");
            _item = new Item(new string[] { "gem" }, "Shiny Gem", "A sparkling gem lies here.");
            _location.Inventory.Put(_item);
        }

        [Test]
        public void LocationCanIdentifyItself()
        {
            Assert.AreEqual(_location, _location.Locate("cave"));
        }

        [Test]
        public void LocationCanLocateItemInInventory()
        {
            Assert.AreEqual(_item, _location.Locate("gem"));
        }

        [Test]
        public void LocationCannotLocateNonexistentItem()
        {
            Assert.IsNull(_location.Locate("sword"));
        }
    }
}
