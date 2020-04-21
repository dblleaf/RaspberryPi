using System;
using System.Threading;

namespace RaspberryPi.EClock
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            while (true)
            {
                clock.ShowTime(DateTime.Now);
            }
        }
    }
}
