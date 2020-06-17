using MongoDB.Driver;
using StoryService.Entities;
using StoryService.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        public readonly IMongoCollection<Story> _storys;
        public StoryRepository(IStoryServiceDatastoreSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _storys = database.GetCollection<Story>(settings.StoryCollection);
        }
        public async Task<Story> Create(Story story)
        {
            await _storys.InsertOneAsync(story);
            return story;
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Story> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Story> Get(string Title)
        {
            throw new NotImplementedException();
        }

        public async Task<Story> Update(Guid id, Story storyIn)
        {
            throw new NotImplementedException();
        }
    }
}
