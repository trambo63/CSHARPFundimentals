﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Operators
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ComparisonOperators()
        {
            int age = 142;
            string userName = "Sandy";
            bool equals = age == 12;
            bool userIsAdam = userName == "SpongeBob";

            bool notEqual = age != 1001;
            bool userIsNotPatrick = userName != "Partrick";
            bool testBool = false;

            List<string> firstList = new List<string>();
            firstList.Add(userName);

            List<string> secondList = new List<string>();
            secondList.Add(userName);
            bool listsAreEqual = firstList == secondList;
            bool itemOnList = firstList[0] == secondList[0];
            Console.WriteLine(listsAreEqual);
            Console.WriteLine(itemOnList);

            bool greaterThan = age > 10;
            bool greaterThanOrEqual = age >= 142;
            bool lessThan = age < 9001;
            bool lessThanOrEqual = age <= 142;

            bool orValue = greaterThan || lessThan;
            bool anotherOr = age < 9005 || userName == "Banana";

            bool andValue = greaterThan && lessThan;
            bool anotherAnd = userName == "Sandy" && age >= 42;



        }
    }
}
