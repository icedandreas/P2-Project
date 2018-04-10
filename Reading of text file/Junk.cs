/*
   The purpose of this class is to have a place to store all the code that is no longer in use.
   Some of it might still be usefull at a later time, thus it was moved here instead of deleted.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A312a_Recommender_System
{
    class Junk
    {
        //    int i = 0;
        //    int counter = 2;
        //    string line;
        //    string[] MovieMovieID;
        //    string[] movieSort = new string[110000];
        //    string movieLine;
        //    int movieCount = 1;
        //    string[] RatingsMovieID;
        //    string[] RatingsRating;
        //    string rute = System.IO.Path.GetFullPath("Dataset/") + "ratingsSorted.csv";
        //    string path = System.IO.Path.GetFullPath("Dataset/") + "Ratings.csv";
        //    string moviePath = System.IO.Path.GetFullPath("Dataset/") + "movies.csv";
        //    using (System.IO.StreamReader movies =
        //    new System.IO.StreamReader(moviePath))
        //    {
        //        using (StreamReader ratingdata =
        //            new StreamReader(path))
        //        {
        //            using (StreamWriter ratings =
        //                new StreamWriter(rute))
        //            {
        //                while ((movieLine = movies.ReadLine()) != null)
        //                {
        //                    MovieMovieID = movieLine.Split(',');
        //                    Console.WriteLine(MovieMovieID[i]);

        //                    while ((line = ratingdata.ReadLine()) != null)
        //                    {
        //                        RatingsMovieID = line.Split(',');
        //                        Console.WriteLine(RatingsMovieID[movieCount]);
        //                        if(MovieMovieID[i] == RatingsMovieID[movieCount])
        //                        {
        //                            Console.WriteLine(RatingsMovieID[counter]);
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Fail");
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    System.Console.ReadKey();
    }
}





/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class CreateUser
    {
        public void CreateUserFunction()
        {
            Console.WriteLine("You have chosen to create a new user profile. Chose a username.");

            string line;
            string userpath = Path.GetFullPath("Users/") + "Users.csv";

            using (StreamWriter fil =
                  new StreamWriter(userpath))
            {
                using (StreamReader file =
                        new StreamReader(userpath))
                {
                    while ((line = file.ReadLine()) != null)
                    {

                    }
                }
            }

            Console.WriteLine("Chose a password.");
        }
    }
}*/