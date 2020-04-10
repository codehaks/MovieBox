using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet(int id)
        {
            using var db = new LiteDB.LiteDatabase("movies.db");
            var movies = db.GetCollection<Movie>();

            Movie = movies.FindById(id);
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