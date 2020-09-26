using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class Show : StreamingContent
    {
        public int SeasonCount { get; set; }

        public int EpisodeCount { get; set; }

        public double AverageRunTime { get; set; }

        public List<Episode> Episode { get; set; } = new List<Episode>();
        //public Show() { }

        //public Show(string title, string description, float starRating, MaturityRating mRating, bool isFamFriendly, GenreType tOG, int seasonCount, int episodeCount, double averageRunTime)
        //    //:base instead of make constructors again
        //    : base(title, description, starRating, mRating, isFamFriendly, tOG)
        //{
        //    SeasonCount = seasonCount;
        //    EpisodeCount = episodeCount;
        //    AverageRunTime = averageRunTime;
        //}
    }


    public class Episode
    {
        public string Title { get; set; }

        public double RunTime { get; set; }

        public int SeasonNumber { get; set; }
    }

}
