using StoryService.Entities;
using StoryService.Exceptions;
using StoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public class PageService : IPageService
    {
        private readonly IStoryRepository _storyRepository;
        public PageService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }
        public async Task<Story> AddPageToStory(string content, Guid storyId)
        {
            var story = await _storyRepository.Get(storyId);
            if(story == null)
            {
                throw new StoryNotFoundException(storyId);
            }
            var nextPageNumber = 0;
            try
            {
                var highestnumber = Convert.ToInt32(story.Pages.Keys.Max());
                nextPageNumber = highestnumber + 1;
            }
            catch(Exception ex)
            {
                nextPageNumber = 1;
            }
            story.Pages.Add(nextPageNumber.ToString(), new Page() { Id = Guid.NewGuid(), Content = content });
            await _storyRepository.Update(storyId, story);
            return story;




        }
    }
}
