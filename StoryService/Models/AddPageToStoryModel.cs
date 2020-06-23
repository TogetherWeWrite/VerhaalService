using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Models
{
    public class AddPageToStoryModel
    {
        public string Content { get; set; }
        public Guid StoryId { get; set; }
    }
}
