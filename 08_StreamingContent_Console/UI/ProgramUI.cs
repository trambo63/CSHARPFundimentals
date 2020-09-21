using _07_RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Console.UI
{
    class ProgramUI
    {
        //readonly alows adding but NOT overiding 
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select: \n" + 
                    "1) Show all streaming content \n" + 
                    "2) Find by title \n" +
                    "3) Add new content \n" + 
                    "4) Remove content \n" +
                    "5) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Show All
                        ShowAllContent();
                        break;
                    case "2":
                        //Find by title
                        FindByTitle();
                        break;
                    case "3":
                        //Add New
                        CreateNewContent();
                        break;
                    case "4":
                        //Remove
                        RemoveContentFromList();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //this is private because we only want to accsess this method here
        private void CreateNewContent()
        {
            // a new content object
            StreamingContent content = new StreamingContent();
            //Ask user for information
            //Title
            Console.WriteLine("Please enter the title of the ne content");
            content.Title = Console.ReadLine();
            //Description          //interpolation
            Console.WriteLine($"Please enter the description for {content.Title}");
            content.Description = Console.ReadLine();
            //StarRating
            Console.WriteLine($"Please enter the star rating for {content.Title}"); content.StarRating = float.Parse(Console.ReadLine());
            //Maturity Rating
            Console.WriteLine("Select a Maturity Rating: \n" +
                "1) G \n" +
                "2) PG \n" +
                "3) PG 13 \n" +
                "4) R \n" +
                "5) NC 17 \n" + 
                "6) MA");
            string maturityResponse = Console.ReadLine();
            switch (maturityResponse)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;
                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRating = MaturityRating.PG_13;
                    break;
                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;
                case "5":
                    content.MaturityRating = MaturityRating.NC_17;
                    break;
                case "6":
                    content.MaturityRating = MaturityRating.MA;
                    break;
            }
            //TypeOfGenre
            Console.WriteLine("Select a genre: \n" +
                "1) Horror \n" +
                "2) RomCom \n" +
                "3) Fanasy \n" +
                "4) Sci-Fi \n" +
                "5) Drama \n" +
                "6) Bromance \n" +
                "7) Action \n" +
                "8) Documentary \n" +
                "9) Thriller");
            string genreResponse = Console.ReadLine();
            //Parse converts string to int32
            int genreID = int.Parse(genreResponse);
            content.TypeOfGenre = (GenreType)genreID;

            //a new content with properties filled out by user
            //Pass that to the add method in our repo
            _streamingRepo.AddContentToDirectory(content);
        }

        private void ShowAllContent()
        {
            Console.Clear();
            //Get the items from our fake database
            List<StreamingContent> listOfContent = _streamingRepo.GetContents();
            //Take EACH item and display proprty values
            foreach (StreamingContent content in listOfContent)
            {
                DisplaySimple(content);
            }
            //Pause the program so the user can see the printed objects
            Console.WriteLine("Press any key to continue...............");
            Console.ReadKey();
            //GOAL: Show all items in our fake database
        }

        private void FindByTitle()
        {
            Console.Clear();
            Console.WriteLine("Enter Name of Title: ");
            string response = Console.ReadLine();
            Console.Clear();
            StreamingContent titleToCheck = _streamingRepo.GetContentByTitle(response);

            //if (response.ToLower() == titleToCheck.Title.ToLower())
            //{
            //    Console.WriteLine($"{titleToCheck.Title} \n" +
            //        $"about: { titleToCheck.Description}");
            //}
            if (titleToCheck != null)
            {
                DisplayAllProps(titleToCheck);
            }
            else 
            {
                Console.WriteLine("This title can not be found");
            }
            Console.WriteLine("Press any key to return to main.............");
            Console.ReadKey();
        }

        private void RemoveContentFromList()
        {
            Console.WriteLine("Which item would you like to remove?");
            //need a list of items
            List<StreamingContent> contentList = _streamingRepo.GetContents();
            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                Console.WriteLine($"{count}) {content.Title}");
            }
            //take in user response
            int targetContentID = int.Parse(Console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex <= 0 && correctIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[correctIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Title} successfully removed!");
                }
                else
                {
                    Console.WriteLine("I'm sorry Dave. I'm afriad I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void DisplaySimple(StreamingContent content)
        {
            Console.WriteLine($"{content.Title} \n" +
                $"{content.Description} \n" +
                $"----------------------");
        }

        private void DisplayAllProps(StreamingContent content)
        {
            Console.WriteLine($"{content.Title} \n" +
                $"Discription: {content.Description} \n" +
                $"Genre: {content.Description} \n" +
                $"Starts: {content.StarRating} \n" +
                $"Content is Family Friendly: {content.IsFamilyFriendly} \n" +
                $"Maturity Rating : {content.MaturityRating}");
        }

        private void SeedContent()
        {
            var titleOne = new StreamingContent("Toy Story", "Toys have a story", 4.5f, MaturityRating.PG, false, GenreType.Bromance);
            var titleTwo = new StreamingContent("Top Gun", "Navy, Airplans", 5.5f, MaturityRating.PG_13, false, GenreType.Bromance);
            var titleThree = new StreamingContent("The Exorsist", "Girl gets possesed", 10, MaturityRating.R, false, GenreType.Horror);
            var titleFour = new StreamingContent("Green Inferno", "Activist's get eaten", 3.5f, MaturityRating.R, false, GenreType.Horror);
            var titleFive = new StreamingContent("Star Trek: The Motion Picture", "People in space", 6.5f, MaturityRating.PG, false, GenreType.SciFi);
            _streamingRepo.AddContentToDirectory(titleOne);
            _streamingRepo.AddContentToDirectory(titleTwo);
            _streamingRepo.AddContentToDirectory(titleThree);
            _streamingRepo.AddContentToDirectory(titleFour);
            _streamingRepo.AddContentToDirectory(titleFive);
        }

        
    }
}
