using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running(
            new DateTime(2022, 11, 3),
            30,
            4.8);

        Cycling cycling = new Cycling(
            new DateTime(2022, 11, 4),
            45,
            20.0);

        Swimming swimming = new Swimming(
            new DateTime(2022, 11, 5),
            40,
            30);

        List<Activity> activities = new List<Activity>
        {
            running,
            cycling,
            swimming
        };

        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}