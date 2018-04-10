/*
The purpose of this class is to introduce the user to the program, and then make the user chose which function to use. 
If the user fails to chose a function, the program will start over.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A312a_Recommender_System
{
    class ChoseAFunction
    {
        public void ChoseFunction()
        {
            Console.WriteLine("Welcome to our Movie Recommender software.");
            Console.WriteLine("Press 1 to launch the function for generating textfiles with the different Genres in them");
            Console.WriteLine("Press 2 to launch the function for generating a textfile with the movieratings and sort them alphabetically");
            Console.WriteLine("Press 3 to access the user login system");
            Console.WriteLine("Press 4 to asdas");
            Console.WriteLine("Press 5 for picture download");
            Console.WriteLine("Press 6 for highest average rated");
            Console.WriteLine("Press 7 to run to GUI");

            string UserInput = Console.ReadLine();
            int ChosenFunction;
            Int32.TryParse(UserInput, out ChosenFunction);

            switch (ChosenFunction)
            {
                case 1:
                    CreateGenreTextFiles GenreFiles = new CreateGenreTextFiles();
                    GenreFiles.CreateGenreTextFilesFunction();
                    break;

                case 2:
                    SortingMovieIdInRatingsFile sort = new SortingMovieIdInRatingsFile();
                    sort.SortingMovieIdInRatingsFileFunction();
                    break;

                case 3:
                    Login mainlogin = new Login();
                    Application.Run(mainlogin);
                    break;

                case 4:
                    GenreSortedByRatings genreSort = new GenreSortedByRatings();
                    genreSort.GenreSortedByRatingsMethod();
                    break;

                /*case 5:
                    GetPictures pictures = new GetPictures();
                    pictures.GetPicturesVoid();
                    break;*/

                case 6:
                    HighestRated highrated = new HighestRated();
                    highrated.HighestRatedMethod();
                    break;

                case 7:
                    GUI openGUI = new GUI();
                    Application.Run(openGUI);
                    break;

                default:
                    Console.WriteLine("No function was chosen. Press Enter to chose again");
                    Console.ReadLine();
                    ChoseFunction();
                    break;
            }
        }
    }
}
