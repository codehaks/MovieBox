using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Common;
using MyApp.Models;

namespace MyApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public IList<Movie> MovieList { get; set; }
        public void OnGet([FromServices]LiteDbContext db)
        {
           
                var movies = db.Context.GetCollection<Movie>();
                MovieList = movies.FindAll().ToList();
           
        }
    }
}