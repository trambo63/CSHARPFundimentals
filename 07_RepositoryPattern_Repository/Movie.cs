using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public class Movie : StreamingContent
    {
        public double RunTime { get; set; }

        //Empty Movie Constructor
        public Movie() {}

        public Movie(string title, string description, float starRating, MaturityRating mRating, GenreType tOG, double runTime)
            //:base instead of make constructors again
            :base(title, description, starRating, mRating, tOG)
        {
            RunTime = runTime;
        }
    }
}
