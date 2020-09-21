using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenges
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConditionalsAndLoops()
        {
            string word = "Supercalifragilisticexpialidocious";
            foreach (char letter in word)
            {
                Console.WriteLine(letter);
            }
        }
        [TestMethod]
        public void printI()
        {
            string word = "Supercalifragilisticexpialidocious";
            foreach (char letter in word)
            {
                if (letter != 'i')
                {
                    Console.WriteLine("not an i");
                }
                else
                {
                    Console.WriteLine("i");
                }
            }
        }
    }
}
