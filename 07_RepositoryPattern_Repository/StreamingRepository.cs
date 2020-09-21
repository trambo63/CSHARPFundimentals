using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class StreamingRepository : StreamingContentRepository 
    {
        public Show GetShowByTitle(string title)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Show)) 
                {
                    return (Show)content;
                }
            }
            return null;
        }
        public Movie GetMovieByTitle(string title)
        {
            foreach (Movie content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Movie))
                {
                    return (Movie)content;
                }
            }
            return null;
        }

        public List<Show> GetAllShows()
        {
            //pull one item and see if it is a show
            List<Show> allShow = new List<Show>();
            //pull one item and see if it is a show
            //make sure to save that off to the side
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Show)
                {
                    allShow.Add((Show)content);
                }
            }
            //return that list
            return allShow;
        }

        public Show GetShowByStarRating(float starRating)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.StarRating == starRating && content.GetType() == typeof(Show))
                {
                    return (Show)content;
                }
            }
            return null;
        }

        public Movie GetMovieByDescription(string description)
        {
            foreach (Movie content in _contentDirectory)
            {
                if (content.Description.ToLower() == description.ToLower() && content.GetType() == typeof(Movie))
                {
                    return (Movie)content;
                }
            }
            return null;

            
        }
            //Get Shows that are over x episode
            //going to pass in value (x) that 
            //single out all shows from my list (aka fake database)
            //now I have a list of shows
            //use parameter Episodes to get episode count
            //using that numbe compared to the number passed in, add it to a list
            //return a list
            public List<Show> GetAllShowsOverACertainEpisodeCount(int episodeCount)
            {
                List<Show> finalList = new List<Show>();
                var listOfAllShows = GetAllShows();
                foreach (var eachShow in listOfAllShows)
                {
                    if (eachShow.Episode.Count() >= episodeCount)
                    {
                        finalList.Add((Show)eachShow);
                    }
                }
                return finalList;
            }
    }
}
