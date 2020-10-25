using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MongoDB.Driver;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class MovieController:ODataController
    {
        [EnableQuery]
         public IActionResult Get()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("movieBoxDb");
            var movies = db.GetCollection<Movie>("movies");


            var movieList = movies.Find(FilterDefinition<Movie>.Empty).ToList();
            return Ok(movieList);
        }
    }
}
