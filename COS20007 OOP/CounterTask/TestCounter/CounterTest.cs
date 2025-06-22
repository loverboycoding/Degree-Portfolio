using CounterTask;
using NUnit.Framework;

namespace TestCounter
{
    [TestFixture]
    public class CounterTest
    {
        // Test that initializing the Counter starts at 0
        [Test]
        public void TestCounterInitialization()
        {
            Counter c = new Counter("TestCounter");
            Assert.That(c.Ticks, Is.EqualTo(0));
        }

        // Test that incrementing the Counter adds one to the count
        [Test]
        public void TestCounterIncrement()
        {
            Counter c = new Counter("TestCounter");
            c.Increment();
            Assert.That(c.Ticks, Is.EqualTo(1));
        }

        // Test that incrementing multiple times increases the count by the correct amount
        [Test]
        public void TestCounterMultipleIncrements()
        {
            Counter c = new Counter("TestCounter");
            for (int i = 0; i < 5; i++)
            {
                c.Increment();
            }
            Assert.That(c.Ticks, Is.EqualTo(5));
        }

        
        [Test]
        public void TestCounterReset()
        {
            Counter c = new Counter("TestCounter");
            c.Increment();
            c.Increment();
            c.Reset();
            Assert.That(c.Ticks, Is.EqualTo(0));
        }
    }
}
