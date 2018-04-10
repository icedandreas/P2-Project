using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace A312a_Recommender_System
{
    class GetPictures
    {
        public void GetPicturesVoid()
        {
            //string linksPath = Path.GetFullPath("Dataset/" + "links.csv");
            //string picturePath = Path.GetFullPath("Pictures/" + "Pictures.csv");
            //string movieLine;
            //string link;
            //string[] movieLineBrackets;
            //using (StreamReader linksFile = new StreamReader(linksPath))
            //{
            //    using (StreamWriter pictureFile = new StreamWriter(picturePath))
            //    {
            //        while ((movieLine = linksFile.ReadLine()) != null)
            //        {
            //            movieLineBrackets = movieLine.Split(',');
            //            link = movieLineBrackets[0] + "," + "https://www.themoviedb.org/movie/" + movieLineBrackets[2];
            //            pictureFile.WriteLine(link);
            //        }
            //    }
            //}
            //PictureDownloadMethod();
            //PictureDownloading();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
        public void PictureDownloadMethod()
        {
            string picturePath = Path.GetFullPath("Pictures/" + "Pictures.csv");
            string pictureLinksPath = Path.GetFullPath("Pictures/" + "PictureLinks.csv");
            string pictureLine;
            string[] pictureBrackets;
            List<string> pictureList = new List<string>();
            using (StreamReader pictureFile = new StreamReader(picturePath))
            {
                using (StreamWriter pictureLinksFile = new StreamWriter(pictureLinksPath))
                {
                    while ((pictureLine = pictureFile.ReadLine()) != null)
                    {
                        pictureBrackets = pictureLine.Split(',');
                        try
                        {
                            WebClient web = new WebClient();
                            string hej = pictureBrackets[1];
                            string html = web.DownloadString(hej);
                            {
                                MatchCollection PictureLink = Regex.Matches(html, "<img itemprop=\"image\" id=\"upload_poster\" alt=\"(.*?)src=\"(.*?)\"", RegexOptions.Singleline);
                                pictureList.Clear();
                                foreach (Match i in PictureLink)
                                {
                                    string name = i.Groups[2].Value;
                                    pictureList.Add(name);
                                    pictureLinksFile.WriteLine(pictureBrackets[0] + "," + name);
                                    Console.WriteLine(pictureBrackets[0] + "," + name);
                                }
                            }
                        }
                        catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
                        {
                        }
                    }
                }
            }
        }
        public void PictureDownloading()
        {
            string picturePath = Path.GetFullPath("Pictures/" + "PictureLinks.csv");
            string pictureLine;
            string[] pictureLineBrackets;
            int movie = 0;
            int picture = 0;
            using (StreamReader pictureFile = new StreamReader(picturePath))
            {
                while ((pictureLine = pictureFile.ReadLine()) != null)
                {
                    movie++;
                    pictureLineBrackets = pictureLine.Split(',');
                    string pictureFolderPath = Path.GetFullPath("Pictures/" + "Pictures/" + pictureLineBrackets[0] + ".jpg");
                    using (WebClient client = new WebClient())
                    {
                        picture++;
                        client.DownloadFile(pictureLineBrackets[1], pictureFolderPath);
                        Console.WriteLine("movie: {0} picture: {1}", movie, picture);
                    }
                }
            }
        }
    }
}

