using System;
using System.Collections.Generic;
using System.Text;

namespace DegreesFromKevinBacon
{
    class MovieData
    {
        public string MovieName { get; set; }
        public List<Actor> ActorList { get; set; }

        public MovieData()
        {
            ActorList = new List<Actor>();
        }



        public void ActedInMostMovies()
        {

        }
    }
}
