using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace LetsRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LetsRun!!");
            Console.WriteLine("\tDid you run Today? Y/N");
            var responseDidTheyRun = Console.ReadKey().KeyChar;
            var run = new Run();

            if (responseDidTheyRun == 'y')
            {
                run.Ran = true;
                Console.WriteLine("Thanks for running!");

            }
            else if (responseDidTheyRun == 'n')
            {
                run.Ran = false;
                Console.WriteLine("You should run more.");
            }
            else
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                //Log error to txt file
                return;
            }

            if (run.Ran == false) { return; }

            Console.WriteLine("Since you ran, how far did you run? Enter Distance in Miles");
            var responseHowFarRan = Console.ReadLine();
            if (!decimal.TryParse(responseHowFarRan, out decimal howFarRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Distance = howFarRan;

            Console.WriteLine("How long did it take you to run?");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan HowLongRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Duration = HowLongRan;

            Console.WriteLine("Ran: = + run.Ran");
            Console.WriteLine("Distance: " + run.Distance);
            Console.WriteLine("Duration: " + run.Duration);

            string fileName = "Run.json";
            string jsonString = JsonSerializer.Serialize(run);
            File.WriteAllText(fileName, jsonString);

            var runtext = File.ReadAllText(fileName);
            var MyRun = JsonSerializer.Deserialize<Run>(runtext);
            Console.WriteLine(MyRun.Distance);
            Console.ReadLine();
        }
    }

}
