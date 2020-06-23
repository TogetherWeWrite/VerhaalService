using StoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Repositories
{
    public interface IWorldRepository
    {
        /// <summary>
        /// Will return world or null
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="World"/> or null</returns>
        Task<World> Get(Guid id);
        /// <summary>
        /// Will return world or null
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="World"/> or null</returns>
        Task<World> Get(string title);
        /// <summary>
        /// Will Update World and returned updated entity
        /// </summary>
        /// <param name="id">Id of the world that will be updated</param>
        /// <param name="worldIn">Updated entity</param>
        /// <returns>updated entity</returns>
        /// <exception cref="WorldNotFoundException">When the world you try to update doesn't exist</exception>
        Task<World> Update(Guid id, World worldIn);
        Task<World> Create(World world);
        Task Delete(Guid id);
    }
}
