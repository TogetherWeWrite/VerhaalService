using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoryService.Entities;
using StoryService.Models;
using StoryService.Services;

namespace StoryService.Controllers
{
    [Route("page")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(AddPageToStoryModel model)
        {
            try
            {
                return Ok(await _pageService.AddPageToStory(model.Content, model.StoryId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}