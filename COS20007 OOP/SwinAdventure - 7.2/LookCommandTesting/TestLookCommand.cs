using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LookCommandTests
    {
        private Player _player;
        private LookCommand _lookCommand;
        private Item _gem;
        private Bag _bag;

        [SetUp]
        public void Setup()
        {
            // Initialize LookCommand
            _lookCommand = new LookCommand();

            // Initialize player, gem, and bag
            _player = new Player("Player", "A brave adventurer");
            _gem = new Item(new string[] { "gem" }, "a gem", "A shiny red gem");
            _bag = new Bag(new string[] { "bag" }, "a small bag", "A small leather bag");

            // Add gem to the player's inventory
            _player.Inventory.Put(_gem);

            // Add the bag to the player's inventory
            _player.Inventory.Put(_bag);

            // Add another gem to the bag
            Item anotherGem = new Item(new string[] { "gem" }, "another gem", "Another shiny gem");
            _bag.Inventory.Put(anotherGem);
        }

        [Test]
        public void TestLookAtMe()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "inventory" });
            Assert.AreEqual("You are Player, A brave adventurer. You are holding \tA shiny red gem (gem)\n\tA small leather bag (bag)\n", result);
        }

        [Test]
        public void TestLookAtGem()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
            Assert.AreEqual("a gem: A shiny red gem", result);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "unknown" });
            Assert.AreEqual("I cannot find the unknown in  Player", result);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" });
            Assert.AreEqual("a gem: A shiny red gem", result);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual("another gem: Another shiny gem", result);
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "nonexistentbag" });
            Assert.AreEqual("I cannot find the nonexistentbag", result);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            Player player = new Player("Player", "A brave adventurer");
            Bag smallBag = new Bag(new string[] { "small bag" }, "small bag", "A small leather bag");

            Item anotherGem = new Item(new string[] { "another gem" }, "another gem", "Another shiny gem");
            player.Inventory.Put(smallBag);
            smallBag.Inventory.Put(anotherGem);

            LookCommand lookCommand = new LookCommand();
            string result = lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "small bag" });

            Assert.AreEqual("I cannot find the gem in  small bag", result);
        }


        [Test]
        public void TestInvalidLook()
        {
            string result = _lookCommand.Execute(_player, new string[] { "hello" });
            Assert.AreEqual("I don't know how to look like that", result);
        }
    }
}
