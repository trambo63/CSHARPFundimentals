using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class ReferenceTypeExamples
    {
        [TestMethod]
        public void Strings()
        {
            string thisIsDeclaration;

            string declared;
            declared = "This is initialized.";

            string declarationAndInitialization = "This is both declaraing and initializzing.";

            //concatenation

            string firstName = "Robert";
            string lastName = "Billiam";
            string space = " ";
            string concatenatedFullName = firstName + space + lastName;
            int age = 112;

            //composite
            string compostieFullName = string.Format("{2}. Hello, I am {0} {1}. Attorney at law. ", firstName, lastName, age);

            //interpolation
            string interpolationFullName = $"{lastName}, {firstName} {lastName}. I am {age}.";
            Console.WriteLine(concatenatedFullName);
            Console.WriteLine(compostieFullName);
            Console.WriteLine(interpolationFullName);
        }

        [TestMethod]
        public void Collections()
        {
            //Arrays
            string stringExample = "Hello World";

            string[] stringArray = { "Hello", "World", "Why", "is it", "always", stringExample, "?" };

            string thirdItem = stringArray[2];
            Console.WriteLine(thirdItem);
            Console.WriteLine(stringArray[2]);
            Console.WriteLine(stringArray[0]);
            stringArray[0] = "Hey there";
            Console.WriteLine(stringArray[0]);
        }
    }
}
