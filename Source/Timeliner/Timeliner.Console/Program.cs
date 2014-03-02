using System;
using Timeliner.Models;

namespace Timeliner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeline = new Timeline();

            timeline.Goals.Add(new Goal("Milestone 1")
            {
                StartDate = DateTime.Now,
                Duration = new TimeSpan(20, 0, 0, 0),
            });

            timeline.Goals.Add(new Goal("Milestone 2")
            {
                Predecessor = "Milestone 1",
                Duration = new TimeSpan(10, 0, 0, 0)
            });

            timeline.Goals.Add(new Goal("Milestone 3")
            {
                Predecessor = "Milestone 1",
                Duration = new TimeSpan(30, 0, 0, 0)
            });

            timeline.Generate();

            foreach (var goal in timeline.Goals)
            {
                Console.WriteLine("Goal {0}: Start Date: {1:dd/MM/yyyy} End Date: {2:dd/MM/yyyy} Duration: {3} days", goal.Name, goal.StartDate, goal.EndDate, goal.Duration.TotalDays);
            }

            Console.ReadLine();
        }
    }
}
