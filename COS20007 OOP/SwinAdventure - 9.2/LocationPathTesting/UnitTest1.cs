using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LocationTests
    {
        private Location _startLocation;
        private Location _destinationLocation;
        private Path _northPath;

        [SetUp]
        public void Setup()
        {
            _startLocation = new Location(new string[] { "start" }, "Starting Location", "The starting point.");
            _destinationLocation = new Location(new string[] { "destination" }, "Destination", "The destination point.");
            _northPath = new Path(Path.Direction.North, _destinationLocation);
            _startLocation.AddPath(_northPath);
        }

        [Test]
        public void TestAddAndRetrievePath()
        {
            Path retrievedPath = _startLocation.GetPath("north");
            Assert.AreEqual(_northPath, retrievedPath);
            Assert.AreEqual(_destinationLocation, retrievedPath.Destination);
        }

        [Test]
        public void TestRetrieveNonExistentPath()
        {
            Path retrievedPath = _startLocation.GetPath("south");
            Assert.IsNull(retrievedPath, "No path should be returned for an invalid direction.");
        }
    }
}
