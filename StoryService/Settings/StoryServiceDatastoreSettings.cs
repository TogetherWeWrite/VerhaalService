using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Settings
{
    public class StoryServiceDatastoreSettings : IStoryServiceDatastoreSettings
    {
        public string StoryCollection { get; set; }
        public string WorldCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStoryServiceDatastoreSettings
    {
        string StoryCollection { get; set; }
        string WorldCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
