using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Mansion.Models
{
    public class Pattern
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("Template")]
        public string Template { get; set; }

        public List<string> Jobs { get; set; }
    }
}