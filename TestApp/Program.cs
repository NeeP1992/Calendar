﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating new event to test SP...");
            Event e = new Event("Some event", DateTime.Now, DateTime.Now.AddHours(2));
            e.Save();
            Console.WriteLine($"Done, new id = {e.Id}");

            WriteEventCountsToConsole();

            Console.WriteLine("Creating new event in the future...");
            e = new Event("Some event", DateTime.Today.AddDays(7), DateTime.Today.AddDays(8));
            e.Save();
            Console.WriteLine($"Done, new id = {e.Id}");

            WriteEventCountsToConsole();

            Console.WriteLine("Press enter to exit");
            string s = Console.ReadLine();
        }

        private static void WriteEventCountsToConsole()
        {
            Console.WriteLine($"Fetching all events = {Event.FetchEvents(false).Count} event(s)");
            Console.WriteLine($"Fetching oustanding events = {Event.FetchEvents().Count} event(s)");
        }
    }
}