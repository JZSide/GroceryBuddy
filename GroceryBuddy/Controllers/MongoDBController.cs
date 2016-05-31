using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace ProductsApp.Controllers
{
    public class MongoDBController : ApiController
    {
        [HttpGet]
        public IHttpActionResult openDB()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("GroceryBuddy");
            var collection = database.GetCollection<BsonDocument>("product");

            var retrieve = collection.Find(new BsonDocument()).ToList();
            return Ok(retrieve.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }));
        }

    }
}