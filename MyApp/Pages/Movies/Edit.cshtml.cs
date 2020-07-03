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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("movieBoxDb");
            var movies = db.GetCollection<Movie>("movies");
            var filter = Builders<Movie>.Filter.Eq(e => e.Id, id);
            Movie = movies.Find(filter).First();
        }

        public IActionResult OnPost()
        {
            using var db = new LiteDB.LiteDatabase("movies.db");

            var movies = db.GetCollection<Movie>();
            movies.Update(Movie);

            return RedirectToPage("Index");
        }
    }
}