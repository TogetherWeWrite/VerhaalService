using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.MqMessages
{
    public class NewWorld
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
