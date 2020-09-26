using _07_RepositoryPattern_Repository;
using _10_StreamingContent_UIRefactor;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Console.UI
{
    public class ProgramUI 
    {
        private readonly IConsole _console;
        //readonly alows adding but NOT overiding 
        private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        public ProgramUI(IConsole console)
        {
            _console = console;
        }
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
                //Get all shows
                //Get all movies
                //Get show/movie by title
                _console.Clear();
                _console.WriteLine("Enter the number of the option you'd like to select: \n" + 
                    "1) Show all streaming content \n" + 
                    "2) Find by title \n" +
                    "3) Add new content \n" + 
                    "4) Remove content \n" +
                    "5) Show all movies \n" +
                    "6) Exit");
                string userInput = _console.ReadLine();
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
                        ShowAllMovies();
                        break;
                    case "6":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //default
                        _console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue......");
                        _console.ReadKey();
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
            _console.WriteLine("Please enter the title of the ne content");
            content.Title = _console.ReadLine();
            //Description          //interpolation
            _console.WriteLine($"Please enter the description for {content.Title}");
            content.Description = _console.ReadLine();
            //StarRating
            _console.WriteLine($"Please enter the star rating for {content.Title}"); content.StarRating = float.Parse(_console.ReadLine());
            //Maturity Rating
            _console.WriteLine("Select a Maturity Rating: \n" +
                "1) G \n" +
                "2) PG \n" +
                "3) PG 13 \n" +
                "4) R \n" +
                "5) NC 17 \n" + 
                "6) MA");
            string maturityResponse = _console.ReadLine();
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
            _console.WriteLine("Select a genre: \n" +
                "1) Horror \n" +
                "2) RomCom \n" +
                "3) Fanasy \n" +
                "4) Sci-Fi \n" +
                "5) Drama \n" +
                "6) Bromance \n" +
                "7) Action \n" +
                "8) Documentary \n" +
                "9) Thriller");
            string genreResponse = _console.ReadLine();
            //Parse converts string to int32
            int genreID = int.Parse(genreResponse);
            content.TypeOfGenre = (GenreType)genreID;

            //a new content with properties filled out by user
            //Pass that to the add method in our repo
            _streamingRepo.AddContentToDirectory(content);
        }

        private void ShowAllContent()
        {
            _console.Clear();
            //Get the items from our fake database
            List<StreamingContent> listOfContent = _streamingRepo.GetContents();
            //Take EACH item and display proprty values
            foreach (StreamingContent content in listOfContent)
            {
                DisplaySimple(content);
            }
            //Pause the program so the user can see the printed objects
            _console.WriteLine("Press any key to continue...............");
            _console.ReadKey();
            //GOAL: Show all items in our fake database
        }

        private void FindByTitle()
        {
            _console.Clear();
            _console.WriteLine("Enter Name of Title: ");
            string response = _console.ReadLine();
            _console.Clear();
            StreamingContent titleToCheck = _streamingRepo.GetContentByTitle(response);

            //if (response.ToLower() == titleToCheck.Title.ToLower())
            //{
            //    _console.WriteLine($"{titleToCheck.Title} \n" +
            //        $"about: { titleToCheck.Description}");
            //}
            if (titleToCheck != null)
            {
                DisplayAllProps(titleToCheck);
            }
            else 
            {
                _console.WriteLine("This title can not be found");
            }
            _console.WriteLine("Press any key to return to main.............");
            _console.ReadKey();
        }

        private void RemoveContentFromList()
        {
            _console.WriteLine("Which item would you like to remove?");
            //need a list of items
            List<StreamingContent> contentList = _streamingRepo.GetContents();
            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                _console.WriteLine($"{count}) {content.Title}");
            }
            //take in user response
            int targetContentID = int.Parse(_console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[correctIndex];
                if (_streamingRepo.DeleteExistingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Title} successfully removed!");
                }
                else
                {
                    _console.WriteLine("I'm sorry Dave. I'm afriad I can't do that.");
                }
            }
            else
            {
                _console.WriteLine("Invalid Option");
            }
            _console.WriteLine("Press any key to continue.........");
            _console.ReadKey();
        }

        private void ShowAllMovies()
        {
            _console.Clear();
            List<Movie> listofMovie = _streamingRepo.GetAllMovies();
            foreach (Movie movie in listofMovie)
            {
                DisplaySimple(movie);
            }
            _console.WriteLine("Press any key to continue...............");
            _console.ReadKey();
        }

        private void DisplaySimple(StreamingContent content)
        {
            _console.WriteLine($"{content.Title} \n" +
                $"{content.Description} \n" +
                $"----------------------");
        }

        private void DisplayAllProps(StreamingContent content)
        {
            _console.WriteLine($"{content.Title} \n" +
                $"Discription: {content.Description} \n" +
                $"Genre: {content.Description} \n" +
                $"Starts: {content.StarRating} \n" +
                $"Content is Family Friendly: {content.IsFamilyFriendly} \n" +
                $"Maturity Rating : {content.MaturityRating}");
        }

        private void SeedContent()
        {
            var titleOne = new StreamingContent("Toy Story", "Toys have a story", 4.5f, MaturityRating.PG, GenreType.Bromance);
            var titleTwo = new StreamingContent("Top Gun", "Navy, Airplans", 5.5f, MaturityRating.PG_13, GenreType.Bromance);
            var titleThree = new StreamingContent("The Exorsist", "Girl gets possesed", 10, MaturityRating.R, GenreType.Horror);
            var titleFour = new StreamingContent("Green Inferno", "Activist's get eaten", 3.5f, MaturityRating.R, GenreType.Horror);
            var titleFive = new StreamingContent("Star Trek: The Motion Picture", "People in space", 6.5f, MaturityRating.PG, GenreType.SciFi);

            Movie movieOne = new Movie();
            Movie movieTwo = new Movie("Speed", "Bus Ramp", 6.5f, MaturityRating.PG_13, GenreType.Action, 120);
            Movie movieThree = new Movie("Con Air", "Nic Cage", 5f, MaturityRating.PG_13, GenreType.Action, 234);
            Movie movieFour = new Movie("Lethal Weapon 5", "Go suck an egg", 10, MaturityRating.PG, GenreType.Bromance, 130);
            _streamingRepo.AddContentToDirectory(titleOne);
            _streamingRepo.AddContentToDirectory(titleTwo);
            _streamingRepo.AddContentToDirectory(titleThree);
            _streamingRepo.AddContentToDirectory(titleFour);
            _streamingRepo.AddContentToDirectory(titleFive);
            _streamingRepo.AddContentToDirectory(movieOne);
            _streamingRepo.AddContentToDirectory(movieTwo);
            _streamingRepo.AddContentToDirectory(movieThree);
            _streamingRepo.AddContentToDirectory(movieFour);
        }


    }
}
