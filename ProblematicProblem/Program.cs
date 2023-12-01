using System;
using System.Collections.Generic;
using System.Threading;
//using System.Linq

namespace ProblematicProblem
{
    class Program
    {


        static List<string> activities = new List<string>() { "Movies ", "Paintball ", "Bowling ", "Lazer Tag ", "LAN Party ", "Hiking ", "Axe Throwing ", "Wine Tasting " };

        public static bool StringToBool(string userInput) //converts user input to a usable bool.
        {
            switch (userInput)  
            {                              
                case "yes":
                    {
                        return true ;
                    }
                case "Yes":
                    {
                        return true;
                    }
                case "Sure":
                    {
                        return true;
                    }
                case "sure":
                    {
                        return true;
                    }
                case "redo":
                    {
                        return true;  
                    }
                case "Redo":
                    {
                        return true;  
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        static void Main(string[] args)
        {

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = StringToBool(Console.ReadLine());
            if (cont == false) // if the user doesnt wish to continue this ends the program
            {
                return;
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");

            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");

            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList = StringToBool(Console.ReadLine());

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = StringToBool(Console.ReadLine());
                Console.WriteLine();

                while (addToList)
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

                    addToList = StringToBool(Console.ReadLine());
                }
            }

                while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                        Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();

                Random rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting ")
                {

                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Picking something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.Write(' ');

                cont = StringToBool(Console.ReadLine());


                }



        }



    }




}