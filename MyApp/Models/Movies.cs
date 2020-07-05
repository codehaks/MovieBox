using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Movie
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
