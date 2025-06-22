using SwinAdventure;
namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PathTests
    {
        private Location _destinationLocation;
        private Path _northPath;

        [SetUp]
        public void Setup()
        {
            _destinationLocation = new Location(new string[] { "destination" }, "Destination", "The destination point.");
            _northPath = new Path(Path.Direction.North, _destinationLocation);
        }

        [Test]
        public void TestPathDestination()
        {
            Assert.AreEqual(_destinationLocation, _northPath.Destination);
            Assert.AreEqual("north", _northPath.FirstId);
        }
    }
}
