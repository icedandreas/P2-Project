using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class HighestRated
    {
        public List<double> HighestAverage = new List<double>();
        public List<string> HighestAverageLine = new List<string>();
        public List<string> HighestAverageMovies = new List<string>();
        //public List<Movielistitem> HighestAverageMovies1 = new List<Movielistitem>();
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
            double[] averageRatingArray = new double[20];
            string[] averageRatingLine = new string[20];
            int numberOfRatings;

            using (StreamReader ratingsFile = new StreamReader(ratingsFilePath))
            {
                while((ratingsLine = ratingsFile.ReadLine()) != null)
                {
                    ratingsLineBrackets = ratingsLine.Split(',');
                    averageRating = Convert.ToDouble(ratingsLineBrackets[1]);
                    if(averageRating > 5)
                    {
                        averageRating = averageRating / 10;
                    }
                    if (averageRating > averageRatingArray[0])
                    {
                        numberOfRatings = Convert.ToInt32(ratingsLineBrackets[2]);
                        if (numberOfRatings >= 150)
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
            string[] movies = new string[20];
            string[] movieAverage = new string[20];
            int index = 0;
            foreach (string n in averageRatingLine)
            {
                tempMovies = n.Split(',');
                topMovies.Add(tempMovies[0]);
                movieAverage[index] = tempMovies[1];
                movies[index] = tempMovies[0];
                index++;
            }
            Array.Reverse(movies);
            Array.Reverse(movieAverage);
            string movieFilePath = Path.GetFullPath("Dataset/" + "movies.csv");
            string movieLine;
            string[] movieLineBrackets;
            int counter = 0;
            while (counter < 20)
            {
                using (StreamReader moviesFile = new StreamReader(movieFilePath))
                {
                    while ((movieLine = moviesFile.ReadLine()) != null)
                    {
                        movieLineBrackets = movieLine.Split(',');
                        if (movies[counter] == movieLineBrackets[0])
                        {
                            Top20MovieID[counter] = movieLineBrackets[0];
                            Top20MovieRating[counter] = movieAverage[counter];
                            Top20MovieName[counter] = movieLineBrackets[1];
                            HighestAverageMovies.Add(movieLineBrackets[0] + "," + movieAverage[counter] + "," + movieLineBrackets[1]);
                            //HighestAverageMovies1
                            break;
                        }
                    }
                }
                counter++;
            }
        }
    }
}
