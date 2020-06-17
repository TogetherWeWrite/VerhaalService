using MongoDB.Driver;
using StoryService.Entities;
using StoryService.Exceptions;
using StoryService.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Repositories
{
    public class WorldRepository : IWorldRepository
    {
        public readonly IMongoCollection<World> _worlds;
        public WorldRepository(IStoryServiceDatastoreSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _worlds = database.GetCollection<World>(settings.WorldCollection);
        }

        public async Task<World> Create(World world)
        {
            await _worlds.InsertOneAsync(world);
            return world;
        }

        public async Task Delete(Guid id)
        {
            await _worlds.DeleteOneAsync(world => world.id == id);
            return;
        }

        public async Task<World> Get(Guid id)
        {
            return await _worlds.Find(world => world.id == id).FirstOrDefaultAsync();
        }

        public async Task<World> Get(string title)
        {
            return await _worlds.Find(world => world.Title == title).FirstOrDefaultAsync();
        }

        public async Task<World> Update(Guid id, World worldIn)
        {
            var oldworld = await Get(id);
            if(oldworld == null)
            {
                throw new WorldNotFoundException(id);
            }
            else
            {
                await _worlds.ReplaceOneAsync(world => world.id == id, worldIn);
                return worldIn;
            }
        }
    }
}
