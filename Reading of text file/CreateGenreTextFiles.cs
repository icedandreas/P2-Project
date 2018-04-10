/*
The purpose of this class is to sort all the movies into textfiles which are devided into different genres.
If no textfiles exists when the program is started, the program will create new textfiles.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A312a_Recommender_System
{
    class CreateGenreTextFiles
    {
        /*
        CreateGenreTextFilesFunction
        In this method we have made a loop, going through all the different genres in our genre string. For each genre, 
        we run through the movie dataset and see if that specific word is in the lines; if it is, then we copy that
        line and put it into the appropriate new genre .txt file
        */
        public void CreateGenreTextFilesFunction()
        {
            string movieDataPath = Path.GetFullPath("Dataset/") + "movies.csv";
            string movieLine;
            string[] genre = new string[] {                                         //genre string
        "Action", "Adventure", "Animation", "Children",
        "Comedy", "Crime", "Documentary", "Drama",
        "Fantasy", "Film-Noir", "Horror", "Musical",
        "Mystery", "Romance", "Sci-Fi", "Thriller",
        "War", "Western" };
            for (int i = 0; i < 18; i++)                                            //loop
            {
                string genrePath = Path.GetFullPath("Genre/") + genre[i] + ".csv";
                using (StreamWriter genreFile =
                  new StreamWriter(genrePath))
                {
                    using (StreamReader movieDataFile =
                        new StreamReader(movieDataPath))
                    {
                        while ((movieLine = movieDataFile.ReadLine()) != null)       //reading movie dataset for each genre
                        {
                            bool check = movieLine.Contains(genre[i]);               //check if line contains keyword and if true, write into .txt file
                            if (check)
                            {
                                genreFile.WriteLine(movieLine);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
