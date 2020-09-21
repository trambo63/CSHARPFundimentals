using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Conditionals
{
    [TestClass]
    public class Turnary
    {
        [TestMethod]
        public void Ternary()
        {
            int age = 31;
            //(conditional/Boolean) ? trueResult : falseResult;
            bool isAdult = (age > 17) ? true : false;

            int numOne = 10; //UserInput
            string outPut = (numOne == 10) ? "You guessed correctly" : "You did not guess correctly";
            Console.WriteLine((outPut == "You guessed correctly") ? "Congrats" : "Try Again");
        }
    }
}
