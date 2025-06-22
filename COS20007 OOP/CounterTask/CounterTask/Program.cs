using System;

namespace CounterTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new Clock instance
            Clock clock = new Clock();

            // Loop to tick the clock and print the time
            for (int i = 0; i < 10; i++) // This will tick the clock 100 times
            {
                clock.Tick();
                Console.WriteLine(clock.ReadTime()); // Print the current time
                
            }

            // Reset the clock and show that it resets to 00:00:00
            clock.Reset();
            Console.WriteLine("Clock reset to: " + clock.ReadTime());
        }
    }
}