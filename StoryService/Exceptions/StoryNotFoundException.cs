using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Exceptions
{
    public class StoryNotFoundException : Exception
    {
        public StoryNotFoundException(Guid id) : base("story with the id: "+ id + "does not exist") { }
    }
}
