using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class GenreSortedByRatings
    {
        public int i = 0;
        public List<string> GenreRatings = new List<string>();
        public List<double> ratingsAverage = new List<double>();
        public List<string> GenreMovieLine = new List<string>();
        public string[] userSelectGenre = new string[] { "Action", "Adventure", "Animation", "Children",
        "Comedy", "Crime", "Documentary", "Drama",
        "Fantasy", "Film-Noir", "Horror", "Musical",
        "Mystery", "Romance", "Sci-Fi", "Thriller",
        "War", "Western" }; //TEMPORARILY SELECTED FOR TESTING
        public void GenreSortedByRatingsMethod()
        {
            string ratingsPath = Path.GetFullPath("Ratings/") + "ratingsSorted.csv";

            string genreLine;
            string[] genreLineSplit;
            string ratingsLine;
            string[] ratingsLineSplit;
            for (i = 0; i < 18; i++)
            {
                string genrePath = Path.GetFullPath("Genre/") + userSelectGenre[i] + ".csv";

                using (StreamReader ratingsFile = new StreamReader(ratingsPath))
                {
                    using (StreamReader genreFile = new StreamReader(genrePath))
                    {
                        while ((genreLine = genreFile.ReadLine()) != null)
                        {
                            genreLineSplit = genreLine.Split(',');
                            while ((ratingsLine = ratingsFile.ReadLine()) != null)
                            {
                                ratingsLineSplit = ratingsLine.Split(',');
                                if (genreLineSplit[0] == ratingsLineSplit[0])
                                {
                                    ratingsAverage.Add(Convert.ToDouble(ratingsLineSplit[1]));
                                    GenreRatings.Add(ratingsLine);
                                    GenreMovieLine.Add(genreLine);
                                    break;
                                }
                            }
                        }
                    }
                }
                SortingGenreArrayMethod();
                GenreRatings.Clear();
                GenreMovieLine.Clear();
                ratingsAverage.Clear();
    }
            Console.WriteLine("done");
            Console.ReadKey();
        }
        public void SortingGenreArrayMethod()
        {
            string genrePath = Path.GetFullPath("Genre/") + userSelectGenre[i] + "TestSorting.csv";
            double[] sortGenreMovieIDs = ratingsAverage.ToArray();
            string[] sortGenreRatings = GenreMovieLine.ToArray();
            int index = 0;
            using (StreamWriter genreTestingFile = new StreamWriter(genrePath))
            {
                Array.Sort(sortGenreMovieIDs, sortGenreRatings);
                Array.Reverse(sortGenreRatings);
                foreach (double ID in sortGenreMovieIDs)
                {
                    genreTestingFile.WriteLine(sortGenreRatings[index]);
                    index++;
                }
            }
        }
    }
}
