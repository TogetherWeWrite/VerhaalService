using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Services
{
    public interface IWorldEditService
    {
        /// <summary>
        /// Used for deleting the world and all its story components
        /// </summary>
        /// <param name="id">The id of the world</param>
        /// <returns></returns>
        Task DeletWorld(Guid id);
    }
}
