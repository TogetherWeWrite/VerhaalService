using StoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Repositories
{
    public interface IStoryRepository
    {
        /// <summary>
        /// Will return a story or null
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Story"/> or null</returns>
        Task<Story> Get(Guid id);

        /// <summary>
        /// Will return a story or null
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Story"/> or null</returns>
        Task<Story> Get(string Title);
        /// <summary>
        /// Will update story and return updated entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storyIn">updated entity</param>
        /// <returns>updated entity</returns>
        /// <exception cref="StoryNotFoundException">When The Story could not be found</exception>
        Task<Story> Update(Guid id, Story storyIn);
        /// <summary>
        /// Deletes a story
        /// <para>[WARNING] Make sure the story is also removed in world repo story list</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// Creates a new story
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        Task<Story> Create(Story story);
    }
}
