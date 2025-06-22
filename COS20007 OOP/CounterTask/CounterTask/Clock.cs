using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterTask;

namespace CounterTask
{
    public class Clock
    {
        private Counter _hour;
        private Counter _minute;
        private Counter _second;

        public Clock() 
        {
            _hour = new Counter("Hour");
            _minute = new Counter("Minute");
            _second = new Counter("Second");

        }
        public void Tick()
        {
            _second.Increment();  // Increment the second counter

            if (_second.Ticks == 60)  // If seconds reach 60, reset and increment minute
            {
                _second.Reset();
                _minute.Increment();
            }

            if (_minute.Ticks == 60)  // If minutes reach 60, reset and increment hour
            {
                _minute.Reset();
                _hour.Increment();
            }

            if (_hour.Ticks == 24)  // If hours reach 24, reset to 0
            {
                _hour.Reset();
            }
        }

        // Method to reset the clock to 00:00:00
        public void Reset()
        {
            _hour.Reset();
            _minute.Reset();
            _second.Reset();
        }

        // Method to read the current time as a string in the format "hh:mm:ss"
        public string ReadTime()
        {
            // Format each component as a 2-digit number with leading zeros if necessary
            return $"{_hour.Ticks:D2}:{_minute.Ticks:D2}:{_second.Ticks:D2}";
        }
    }
}
    
