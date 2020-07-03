using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MyApp.Common;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public IList<Movie> MovieList { get; set; }
        public void OnGet()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("movieBoxDb");
            var movies = db.GetCollection<Movie>("movies");


            MovieList = movies.Find(FilterDefinition<Movie>.Empty).ToList();
           
        }
    }
}