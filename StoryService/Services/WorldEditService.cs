using StoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public class WorldEditService : IWorldEditService
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IStoryRepository _storyRepository;
        public WorldEditService(IWorldRepository worldRepository, IStoryRepository storyRepository)
        {
            _worldRepository = worldRepository;
            _storyRepository = storyRepository;
        }
        public async Task DeletWorld(Guid id)
        {
            var world = await _worldRepository.Get(id);
            await _storyRepository.RemoveRange(world.Stories);
            await _worldRepository.Delete(id);
        }
    }
}
