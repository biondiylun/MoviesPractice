using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DegreesFromKevinBacon
{
    class DataFetcher
    {
        public List<MovieData> GetMovies(string URL)
        {
            List<MovieData> MD = new List<MovieData>();
            string webData;
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData(URL);
                webData = System.Text.Encoding.UTF8.GetString(raw);
            } 
            catch(WebException ex)
            {
                throw ex;
            }

            MD = movieParse(webData);

            return MD;
        }

        private List<MovieData> movieParse(string WebDataStuff)
        {
            List<MovieData> tempMD = new List<MovieData>();
            try
            {
                List<string> webDataList = WebDataStuff.Split("\n").ToList();
                foreach (var webData in webDataList)
                {
                    tempMD.Add(parseOneMovie(webData));
                }
            }
            catch(Exception ex)
            {
                Console.Write("Error parsing string. \r Exception: " + ex);
            }

            return tempMD;
        }

        private MovieData parseOneMovie(string webData)
        {
            MovieData newMovie = new MovieData();
            List<string> movieData = webData.Split("/").ToList();
            newMovie.MovieName = movieData[0];
            foreach (var actor in movieData.Skip(1))
            {
                string[] firstLast = actor.Split(",");
                Actor a = new Actor();
                if (firstLast.Length < 2)
                {
                    a.FirstName = firstLast[0];
                }
                else
                {
                    a.FirstName = firstLast[1];
                    a.LastName = firstLast[0];
                }

                newMovie.ActorList.Add(a);
            }

            return newMovie;
        }
    }
}
