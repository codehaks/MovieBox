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
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("movieBoxDb");
            var movies = db.GetCollection<Movie>("movies");

            Movie = movies.Find(m => m.Id == Movie.Id).First();
        }
    }
}
