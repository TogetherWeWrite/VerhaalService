using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;
using StoryService.Models;
using StoryService.Services;

namespace StoryService.Controllers
{
    [Route("story")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateStoryModel model)
        {
            try
            {
                return Ok(await _storyService.CreateStory(model.WorldId, model.Title));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}