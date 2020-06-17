using StoryService.Entities;
using StoryService.Exceptions;
using StoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IWorldRepository _worldRepository;
        public StoryService(IStoryRepository storyRepository, IWorldRepository worldRepository)
        {
            _storyRepository = storyRepository;
            _worldRepository = worldRepository;
        }
        public async Task<World> CreateStory(Guid worldId, string title)
        {
            // get the world that you want to add a story to
            var world = await _worldRepository.Get(worldId);
            if(world == null)
            {
                throw new WorldNotFoundException(worldId);      
            }
            // new story that you create in the story collection
            var newstory = await _storyRepository.Create(new Story()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Chapters = new Dictionary<string, List<int>>(),
                Pages = new Dictionary<int, Page>()
            });
            // new world that you added storyref too 
            world.Stories.Add(new StoryRef()
            {
                Id = newstory.Id,
                Title = newstory.Title
            });
            //update db and return the world
            return await _worldRepository.Update(world.id, world);
        }
    }
}
