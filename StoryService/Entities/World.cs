using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Entities
{
    public class World
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public List<StoryRef> Stories { get; set; }
    }

    public class StoryRef
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
