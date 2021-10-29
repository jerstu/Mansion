using Mansion.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Mansion.Services
{
    public class PatternService
    {
        private readonly IMongoCollection<Pattern> _patterns;

        public PatternService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _patterns = database.GetCollection<Pattern>(settings.PatternsCollectionName);
        }

        public List<Pattern> Get()
        {
            return (_patterns.Find(pattern => true).ToList());
        }


        public Pattern Get(string id)
        {
            return (_patterns.Find<Pattern>(pattern => pattern.Id == id).FirstOrDefault());
        }

        public Pattern Create(Pattern pattern)
        {
            _patterns.InsertOne(pattern);
            return pattern;
        }

        public void Update(string id, Pattern patternIn) =>
            _patterns.ReplaceOne(pattern => pattern.Id == id, patternIn);

        public void Remove(Pattern patternIn) =>
            _patterns.DeleteOne(pattern => pattern.Id == patternIn.Id);

        public void Remove(string id) =>
            _patterns.DeleteOne(pattern => pattern.Id == id);
    }
}