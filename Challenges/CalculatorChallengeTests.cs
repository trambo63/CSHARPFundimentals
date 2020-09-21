using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenges
{
    [TestClass]
    public class CalculatorChallengeTests
    {
        
        [TestMethod]
        public void AddWillAdd()
        {
            CalculatorChallenge myCal = new CalculatorChallenge();
            //Arrange
            double num1 = 2;
            double num2 = 2;
            double num3 = 4;
            //Act
            double num4 = myCal.Add(num1, num2);
            //Assert
            Assert.IsTrue(num3 == num4);
        }

        [TestMethod]
        public void SubtractWillSubtract()
        {
            CalculatorChallenge myCal = new CalculatorChallenge();
            //Arrange
            double num1 = 2;
            double num2 = 2;
            double num3 = 0;
            //Act
            double num4 = myCal.Subtract(num1, num2);
            //Assert
            Assert.IsTrue(num3 == num4);
        }

        [TestMethod]
        public void MultiplyWillMultiply()
        {
            CalculatorChallenge myCal = new CalculatorChallenge();
            //Arrange
            double num1 = 2;
            double num2 = 2;
            double num3 = 4;
            //Act
            double num4 = myCal.Multiply(num1, num2);
            //Assert
            Assert.IsTrue(num3 == num4);
        }

        [TestMethod]
        public void DivideWillDivide()
        {
            CalculatorChallenge myCal = new CalculatorChallenge();
            //Arrange
            double num1 = 2;
            double num2 = 2;
            double num3 = 1;
            //Act
            double num4 = myCal.Divide(num1, num2);
            //Assert
            Assert.IsTrue(num3 == num4);
        }
    }
}
