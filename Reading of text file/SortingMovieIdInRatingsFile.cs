/*
This class sorts the ratings file, and then creates a new .txt file.
In this .txt file we have 1 line per movie, this line contains
the movieID, the movies average rating and the number of times
this movie has been rated.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class SortingMovieIdInRatingsFile
    {
        public List<string> MovieListData = new List<string>();
        public List<int> IntListMovieID = new List<int>();
        /*
        SortingMovieIdInRatingsFileFunction
        We read the ratings data file and load the data into 2 arrays, one containing
        the movieIDs from each line, the other one containing strings of each line.
        We then call the other 2 methods from this one.
        */
        public void SortingMovieIdInRatingsFileFunction()
        {
            System.Globalization.CultureInfo customCulture =                                                //We change the icon for decimalSeparator from "," to "."
            (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone(); //This is for when we write average rating for a movie into a 
            customCulture.NumberFormat.NumberDecimalSeparator = ".";                                        // .txt file later, since we separate the dataset using ","
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            string RatingsPath = Path.GetFullPath("Dataset/") + "ratings.csv";
            string MovieIDLine;
            string[] RatingsFileMovieID;
            int index = 0;
            using (StreamReader RatingsFile
                = new StreamReader(RatingsPath))
            {
                while ((MovieIDLine = RatingsFile.ReadLine()) != null)                                      //Reading ratings dataset loop
                {
                    RatingsFileMovieID = MovieIDLine.Split(',');                                            //Splitting the current line into an array
                    IntListMovieID.Add(Convert.ToInt32(RatingsFileMovieID[1]));
                    MovieListData.Add(MovieIDLine);
                    index++;
                }
                ArraySortingAndWritingToTextFile();                                                         //Calling the other functions
                AverageRatingsCalculator();
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
        /*
        ArraySortingAndWritingToTextFile
        In this method we sort the 2 arrays from just before based on the movieID 
        array, the string array follows the sorting.
        */
        private void ArraySortingAndWritingToTextFile()
        {
            int index = 0;
            string SortedRatings = Path.GetFullPath("Ratings/") + "ratingsSortedByMovieID.csv";
            string[] MovieData = MovieListData.ToArray();
            int[] IntMovieID = IntListMovieID.ToArray();
            using (StreamWriter SortedRatingsFile = new StreamWriter(SortedRatings))
            {
                Array.Sort(IntMovieID, MovieData);                                                          //Sorting the 2 arrays based on our movieID array (IntMovieID)
                foreach (int ID in IntMovieID)
                {
                    if (ID != 0)
                    {
                        SortedRatingsFile.WriteLine(MovieData[index]);                                      //Writes the line from our string array into a .txt file
                        index++;
                    }
                    else
                    {
                        index++;
                    }
                }

                SortedRatingsFile.Write("0,0,0,0");
            }
        }
        /*
        AverageRatingsCalculator
        In this method we will be reading 2 .txt files and writing data into a 3rd.
        We read the movieIDs in order from our movie dataset, and then check if it matches
        the movieID from our sorted ratings file. If they match we count up the ratings and ratingscounter,
        and continue to do this until they are not a match anymore. We then print the accumulated data to
        our final .txt file (ratingsSorted).
        */
        private void AverageRatingsCalculator()
        {
            string SortedRatings = Path.GetFullPath("Ratings/") + "ratingsSortedByMovieID.csv";
            string SortedRatingsTest = Path.GetFullPath("Ratings/") + "ratingsSorted.csv";
            string MoviesTextFile = Path.GetFullPath("Dataset/") + "movies.csv";
            string SortedMovieLine;
            string[] SortedRatingsMovieID;
            string MovieID;
            string[] MovieIDBracket;
            int RatingsCount = 0;
            double averageRating = 0;
            double ratingsTotal = 0;
            double currentRating = 0;
            using (StreamReader SortedRatingsFile = new StreamReader(SortedRatings))
            {
                using (StreamWriter SortedRatingsFileTest = new StreamWriter(SortedRatingsTest))
                {
                    using (StreamReader MovieFile = new StreamReader(MoviesTextFile))
                    {
                        while ((MovieID = MovieFile.ReadLine()) != null)                                    //Reading movies .txt file loop
                        {
                            MovieIDBracket = MovieID.Split(',');
                            while ((SortedMovieLine = SortedRatingsFile.ReadLine()) != null)                //Reading sorted ratings .txt file loop
                            {
                                SortedRatingsMovieID = SortedMovieLine.Split(',');                          //Splitting the sorted ratings line and
                                currentRating = Convert.ToDouble(SortedRatingsMovieID[2]);                  //getting the current rating
                                if (MovieIDBracket[0] == SortedRatingsMovieID[1])                           //If movieIDs are the same, then we count up
                                {                                                                           //the totalRatings and our RatingsCount
                                    ratingsTotal = ratingsTotal + currentRating;
                                    RatingsCount++;
                                }
                                else {                                                                      //If the movieIDs arent the same, then we calculate
                                    averageRating = ratingsTotal / RatingsCount;                            //the average rating for the current movieID,
                                    averageRating = Math.Round(averageRating, 1);
                                    //if (averageRating == int.len
                                    //{
                                    //    //Convert.ToDouble(averageRating);
                                    //    SortedRatingsFileTest.WriteLine(MovieIDBracket[0] + "," + averageRating + ".0," + RatingsCount);
                                    //    RatingsCount = 1;                                                       //Setting the ratingsCount and ratingsTotal to new values
                                    //    ratingsTotal = currentRating;                                           //as we have begun on the new movieID.
                                    //    break;
                                    //}
                                    //else
                                    //{
                                        //and print the data to our new .txt file
                                        SortedRatingsFileTest.WriteLine(MovieIDBracket[0] + "," + averageRating + "," + RatingsCount);
                                        RatingsCount = 1;                                                       //Setting the ratingsCount and ratingsTotal to new values
                                        ratingsTotal = currentRating;                                           //as we have begun on the new movieID.
                                        break;
                                    //}
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}