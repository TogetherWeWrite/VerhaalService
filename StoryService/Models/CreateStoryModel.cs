using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Models
{
    public class CreateStoryModel
    {
        public Guid WorldId { get; set; }
        public string Title { get; set; }
    }
}
