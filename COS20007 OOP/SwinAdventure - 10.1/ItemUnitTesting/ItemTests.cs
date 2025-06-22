using NUnit.Framework;
using SwinAdventure;
namespace SwinAdventure.Tests
{
    [TestFixture]
    public class ItemTests
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "sword", "weapon" }, "bronze sword", "a sharp bronze sword");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_item.AreYou("sword"));
            Assert.IsTrue(_item.AreYou("weapon"));
            Assert.IsFalse(_item.AreYou("shield"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("a sharp bronze sword", _item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("bronze sword: a sharp bronze sword", _item.GetFullDescription());
        }
    }
}
