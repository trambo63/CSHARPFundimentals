using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Conditionals
{
    [TestClass]
    public class IfElse
    {
        [TestMethod]
        public void IfStatements()
        {
            bool userIsHungry = true;
            if (userIsHungry)
            {
                Console.WriteLine("Go Eat!");
            }

            int hoursSpentStudying = 4;
            if(hoursSpentStudying < 10)
            {
                Console.WriteLine("Are you even trying");
            }
        }

        [TestMethod]
        public void IfElseStatments()
        {
            bool chorseAreDone = false;
            if (chorseAreDone)
            {
                Console.WriteLine("Go have fun playing animal crossing");
            }
            else
            {
                Console.WriteLine("You need to finish your chores, Come on now, I know it is not fun");
            }

            string input = "7";
            int totalHours = int.Parse(input);

            if(totalHours >= 8)
            {
                Console.WriteLine("You Should be well rested");
            }
            else
            {
                Console.WriteLine("You might be tired");
                if (totalHours < 3)
                {
                    Console.WriteLine("You should try and get more sleep");
                }
            }

            int age = 5;
            if (age > 17)
            {
                Console.WriteLine("You are an adult");
            }
            else
            {
                if (age > 12)
                {
                    Console.WriteLine("You are a teenager");
                }
                else if (age > 2)
                {
                    Console.WriteLine("You are just a little kid");
                }
                else
                {
                    Console.WriteLine("How are you on the computer");
                }
            }

            if (age < 65 && age > 18)
            {
                Console.WriteLine("Your age is between 19 and 64");
            }

            if (age < 17 && age >18)
            {
                Console.WriteLine("You can't be less than 17 and more than 18");
            }
        }
    }

}
