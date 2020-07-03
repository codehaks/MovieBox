using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnPost()
        {
            //using var db = new LiteDB.LiteDatabase("movies.db");
            //var movies = db.GetCollection<Movie>();
            //movies.Insert(Movie);

            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("movieBoxDb");
            var movieCollection = db.GetCollection<Movie>("movies");
            movieCollection.InsertOne(Movie);


            return RedirectToPage("Index");
        }
    }
}