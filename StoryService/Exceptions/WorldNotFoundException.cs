using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Exceptions
{
    public class WorldNotFoundException : Exception
    {
        public WorldNotFoundException(Guid id) : base("The world with the id: " + id + "Does not exist") { }
    }
}
