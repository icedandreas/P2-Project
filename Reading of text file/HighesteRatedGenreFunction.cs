using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class HighesteRatedGenreFunction
    {
        public List<double> HighestAverage = new List<double>();
        public List<string> HighestAverageLine = new List<string>();
        public List<string> HighestAverageMovies = new List<string>();
        public string[] Top20MovieName = new string[20];
        public string[] Top20MovieRating = new string[20];
        public string[] Top20MovieID = new string[20];


        public void HighestRatedMethod()
        {
            System.Globalization.CultureInfo customCulture =
            (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            string ratingsFilePath = Path.GetFullPath("Ratings/" + "ratingsSorted.csv");
            string ratingsLine;
            string[] ratingsLineBrackets;
            double averageRating;
            double[] averageRatingArray = new double[100];
            string[] averageRatingLine = new string[100];
            int numberOfRatings;

            using (StreamReader ratingsFile = new StreamReader(ratingsFilePath))
            {
                while ((ratingsLine = ratingsFile.ReadLine()) != null)
                {
                    ratingsLineBrackets = ratingsLine.Split(',');
                    averageRating = Convert.ToDouble(ratingsLineBrackets[1]);
                    if (averageRating > 5)
                    {
                        averageRating = averageRating / 10;
                    }
                    if (averageRating > averageRatingArray[0])
                    {
                        numberOfRatings = Convert.ToInt32(ratingsLineBrackets[2]);
                        if (numberOfRatings >= 116)
                        {
                            averageRatingLine[0] = ratingsLine;
                            averageRatingArray[0] = averageRating;
                            Array.Sort(averageRatingArray, averageRatingLine);
                        }
                    }
                }
            }
            List<string> topMovies = new List<string>();
            string[] tempMovies;
            string[] movies = new string[100];
            string[] movieAverageRating = new string[100];
            int index = 0;
            foreach (string n in averageRatingLine)
            {
                tempMovies = n.Split(',');
                topMovies.Add(tempMovies[0]);
                movieAverageRating[index] = tempMovies[1];
                movies[index] = tempMovies[0];
                index++;
            }
            Array.Reverse(movies);
            Array.Reverse(movieAverageRating);

            string moviefilepath = Path.GetFullPath("genre/" + "Action.csv");
            string movieline;
            string[] movielinebrackets;
            int counter = 0;
            int j = 0;
            while (j < 20)
            {
                using (StreamReader moviesfile = new StreamReader(moviefilepath))
                {
                    while ((movieline = moviesfile.ReadLine()) != null)
                    {
                        movielinebrackets = movieline.Split(',');
                        if (movies[counter] == movielinebrackets[0])
                        {
                            Top20MovieID[j] = movielinebrackets[0];
                            Top20MovieRating[j] = movieAverageRating[counter];
                            Top20MovieName[j] = movielinebrackets[1];
                            HighestAverageMovies.Add(movielinebrackets[0] + "," + movieAverageRating[counter] + "," + movielinebrackets[1]);
                            j++;
                            break;
                        }
                    }
                }
                counter++;
                Console.WriteLine(j);
                Console.WriteLine(counter);
            }
        }


        //public string[] Top20MovieName = new string[20];
        //public string[] Top20MovieRating = new string[20];
        //public string[] Top20MovieID = new string[20];

        //public void HighestRatedMovieGenre()
        //{
        //    string ratingsMovieFilePath = Path.GetFullPath("Ratings/ratingsSorted.csv");
        //    string actionMovieFilePath = Path.GetFullPath("Genre/Action.csv");
        //    string actionFileLine;
        //    string[] ratingFileBrackets;
        //    int counter = 0;
        //    while (counter <= 20)
        //    {
        //        using (StreamReader ratingFile = new StreamReader(ratingsMovieFilePath))
        //        using (StreamReader actionFile = new StreamReader(actionMovieFilePath))
        //        {
        //            while ((actionFileLine = ratingFile.ReadLine()) != null)
        //            {
        //                ratingFileBrackets = actionFileLine.Split(',');
        //                if (ratingFileBrackets[0] != 0)
        //                {

        //                }
        //            }


        //        }
        //    }
        //}
    }
}


