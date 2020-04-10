using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnPost()
        {
            using (var db = new LiteDB.LiteDatabase("movies.db"))
            {
                var movies = db.GetCollection<Movie>();
                movies.Insert(Movie);

            }

            return RedirectToPage("Index");
        }
    }
}