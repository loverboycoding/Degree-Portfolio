using System;
using CounterTask; 

namespace TestClock
{
    [TestFixture]
    public class ClockTest
    {
        // Test that the Clock initializes to 00:00:00
        [Test]
        public void TestClockInitialization()
        {
            Clock clock = new Clock();
            Assert.That(clock.ReadTime(), Is.EqualTo("00:00:00"), "Clock should initialize to 00:00:00.");
        }

        // Test that ticking the Clock updates the seconds
        [Test]
        public void TestClockTickSeconds()
        {
            Clock clock = new Clock();
            clock.Tick();
            Assert.That(clock.ReadTime(), Is.EqualTo("00:00:01"), "Clock should tick to 00:00:01.");
        }

        // Test that ticking the Clock from 00:00:59 updates minutes
        [Test]
        public void TestClockTickMinutes()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 60; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.ReadTime(), Is.EqualTo("00:01:00"), "Clock should tick from 00:00:59 to 00:01:00.");
        }

        // Test that ticking the Clock from 23:59:59 wraps around to 00:00:00
        [Test]
        public void TestClockTickWrapAround()
        {
            Clock clock = new Clock();

            // Manually setting the time to 23:59:59 by ticking 86399 times (total seconds in a day - 1)
            for (int i = 0; i < 86399; i++)
            {
                clock.Tick();
            }

            Assert.That(clock.ReadTime(), Is.EqualTo("23:59:59"), "Clock should be at 23:59:59.");

            // One more tick should reset the clock to 00:00:00
            clock.Tick();
            Assert.That(clock.ReadTime(), Is.EqualTo("00:00:00"), "Clock should wrap around to 00:00:00 after 23:59:59.");
        }

        // Test that resetting the Clock sets the time to 00:00:00
        [Test]
        public void TestClockReset()
        {
            Clock clock = new Clock();
            clock.Tick();
            clock.Tick();
            clock.Reset();
            Assert.That(clock.ReadTime(), Is.EqualTo("00:00:00"), "Clock should reset to 00:00:00.");
        }
    }
}
