using StoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public interface IStoryService
    {
        /// <summary>
        /// Creates a story edits the world entity so it references the story
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="WorldNotFoundException"></exception>
        public Task<World> CreateStory(Guid worldId, string title);
    }
}
