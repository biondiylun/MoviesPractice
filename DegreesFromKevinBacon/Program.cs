using System;
using System.Collections.Generic;

namespace DegreesFromKevinBacon
{
    class Program
    {
        static void Main(string[] args)
        {
            DataFetcher df = new DataFetcher();
            List<MovieData> AllMovies = df.GetMovies("https://s3.amazonaws.com/cdn.limpidfox.com/movies.txt");
            var MostActorMovie = GetMovieWithMostActors(AllMovies);
            Console.WriteLine($"Most actors movie: {MostActorMovie.MovieName}, Num of Actors: {MostActorMovie.ActorList.Count}");

            //Fetch database down
            //Parse and store it in a movie object
            //
        }

        private static MovieData GetMovieWithMostActors(List<MovieData> allMovies)
        {
            MovieData movieWithMostActors = new MovieData();
            foreach (MovieData movie in allMovies)
            {
                if (movie.ActorList.Count > movieWithMostActors.ActorList.Count)
                {
                    movieWithMostActors = movie;
                }
            }

            return movieWithMostActors;
        }

    }
}
