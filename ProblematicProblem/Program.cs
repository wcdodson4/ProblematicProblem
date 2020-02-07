using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        private static readonly Random rng;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = Console.ReadLine().ToLower() == "yes" ? true : false;
            if (cont == false)
            {
                System.Environment.Exit(0);
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? yes/no: ");
            bool seeList = Console.ReadLine().ToLower() == "yes" ? true : false;

            if (seeList == true)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                Console.WriteLine();

                while (addToList == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower() == "yes" ? true : false;

                }
            }
            else
            {
                System.Environment.Exit(0);
            }

            
            while (cont == true)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();

                Console.WriteLine("Choosing your random activity");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();

                var rng = new Random();
                int randomNumber = rng.Next(activities.Count);

                var randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    
                    Console.WriteLine($"Oh no! Looks like you are too young to do Wine Tasting!");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);
                }

                int randomNum = rng.Next(activities.Count);
                var randomAct = activities[randomNum];
                Console.Write($"Ah got it! {userName}, your random activity is: {randomAct}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower() == "redo" ? true : false;
            }
        }
    }
}

