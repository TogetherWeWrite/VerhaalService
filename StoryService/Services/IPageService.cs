using StoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public interface IPageService
    {
        Task<Story> AddPageToStory(string content, Guid storyId);
    }
}
