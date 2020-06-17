using MessageBroker;
using StoryService.Entities;
using StoryService.MqMessages;
using StoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoryService.MessageHandlers
{
    public class WorldMessagehandler : IMessageHandler<NewWorld>
    {
        private readonly IWorldRepository _worldRepository;
        public WorldMessagehandler(IWorldRepository worldRepository)
        {
            _worldRepository = worldRepository;
        }
        

        public Task HandleMessageAsync(string messageType, NewWorld sendable)
        {
            var createworld = new World()
            {
                Id = sendable.Id,
                Stories = new List<StoryRef>(),
                Title = sendable.Title
            };
            _worldRepository.Create(createworld);
            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<NewWorld>((ReadOnlySpan<byte>)obj, (JsonSerializerOptions)null));
        }
    }
}
