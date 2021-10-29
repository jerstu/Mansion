using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mansion.Models
{
    public class Bank
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public List<string> Serials { get; set; }

        public Bank(List<string> serials)
        {
            Serials = serials;
        }
    }
}
