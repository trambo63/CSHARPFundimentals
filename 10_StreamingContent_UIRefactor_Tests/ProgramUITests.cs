using System;
using System.Collections.Generic;
using _08_StreamingContent_Console.UI;
using _10_StreamingContent_UIRefactor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _10_StreamingContent_UIRefactor_Tests
{
    [TestClass]
    public class ProgramUITests
    {
        [TestMethod]
        public void GetList_OutPutShouldContianList()
        {
            //Arrange
            List<string> commandList = new List<string> { "1", "6" };
            MockConsole console = new MockConsole(commandList);
            ProgramUI program = new ProgramUI(console);
            //Act
            program.Run();
            Console.WriteLine(console.Output);

            //Assert
            Assert.IsTrue(console.Output.Contains("People in space"));
        }

        [TestMethod]
        public void AddToList_ShouldSeeItemInList()
        {
            //Arrange
            var customDesc = "This is my custom thoughts on this moive";
            var commandList = new List<string>
            {
                "3",
                "This is the title",
                customDesc,
                "42",
                "3",
                "4",
                "1",
                "6"
            };
            var mockConsole = new MockConsole(commandList);
            var ui = new ProgramUI(mockConsole);
            //Act
            ui.Run();
            Console.WriteLine(mockConsole.Output);
            //Assert
            Assert.IsTrue(mockConsole.Output.Contains(customDesc));
        }

        [TestMethod]
        public void RemoveList_ShouldSeeRemoveMessage()
        {
            //Arrange
            var commandList = new List<string> { "4", "3", "6" };
            var fakeConsole = new MockConsole(commandList);
            var ui = new ProgramUI(fakeConsole);
            //Act
            ui.Run();
            Console.WriteLine(fakeConsole.Output);
            //Assert
            Assert.IsTrue(fakeConsole.Output.Contains("The Exorsist successfully removed!"));
        }

    }
}
