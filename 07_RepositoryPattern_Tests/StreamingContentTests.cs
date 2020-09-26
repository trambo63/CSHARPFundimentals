using System;
using _07_RepositoryPattern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void StreamingContentNotes()
        {
            StreamingContent baseObject = new StreamingContent();
            Movie movieObject = new Movie();
            Show showObject = new Show();
            Episode episodeObject = new Episode();

            showObject.Episode.Add(episodeObject);
            Movie newMovie = new Movie("Venom", "The best romance", 9005, MaturityRating.PG_13, GenreType.RomCom, 132);
        }

        [DataTestMethod]
        [DataRow(MaturityRating.G,true)]
        [DataRow(MaturityRating.PG, true)]
        [DataRow(MaturityRating.PG_13, false)]
        [DataRow(MaturityRating.MA, false)]

        public void SetMaturityRating_ShouldGetCorrectBool(MaturityRating rating, bool isFamilyFriendly)
        {
            StreamingContent content = new StreamingContent("Instert Title Here", "Description here", 5, rating, GenreType.Documentary);
            bool actual = content.IsFamilyFriendly;
            bool expected = isFamilyFriendly;
            Assert.AreEqual(expected, actual);
        }
    }
}
