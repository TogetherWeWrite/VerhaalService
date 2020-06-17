using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Entities
{
    public class Story
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Dictionary<string,List<int>> Chapters { get; set; }
        public Dictionary<int,Page> Pages { get; set; }
    }
    public class Page
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Constraints at 350 words
        /// </summary>
        public string Content { get; set; }
       
    }
}
