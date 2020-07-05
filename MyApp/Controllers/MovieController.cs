using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyApp.Models;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //api/movie
        [HttpGet]
        public IActionResult Get()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("mymoviesdb");
            var movies = db.GetCollection<Movie>("movies");

            var movieList = movies.Find(FilterDefinition<Movie>.Empty).ToList();

            return Ok(movieList);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie model)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("mymoviesdb");
            var movies = db.GetCollection<Movie>("movies");

            movies.InsertOne(model);

            return Ok();
        }
      
    }
}
