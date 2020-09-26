using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_RepositoryPattern_Repository
{
    public enum GenreType
    {
        Horror = 1,
        RomCom,
        Fantasy,
        SciFi,
        Drama,
        Bromance,
        Action,
        Documentary,
        Thriller
    }
    public enum MaturityRating { G, PG, PG_13, R, NC_17, MA}
    //Properites
    public class StreamingContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float StarRating { get; set; }
        public MaturityRating MaturityRating { get; set; }
        public bool IsFamilyFriendly 
        { 
            get
            {
                switch (MaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                        return true;
                    case MaturityRating.PG_13:
                    case MaturityRating.NC_17:
                    case MaturityRating.R:
                    case MaturityRating.MA:
                        return false;
                    default:
                        return false;
                }
                //Alt 
                //if ((int)MaturityRating <= 1)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }
        //Making our enum a property
        public GenreType TypeOfGenre { get; set; }

        public StreamingContent() { }
        //Constructors
        public StreamingContent(string title, string description, float starRating, MaturityRating mRating, GenreType tOG)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            MaturityRating = mRating;
            TypeOfGenre = tOG;
        }
    }
}
