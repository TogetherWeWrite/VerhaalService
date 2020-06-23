using MessageBroker;
using StoryService.MqMessages;
using StoryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoryService.MessageHandlers
{
    public class WorldDeleteMessageHandler : IMessageHandler<DeleteWorld>
    {
        private readonly IWorldEditService _worldEditService;
        public WorldDeleteMessageHandler(IWorldEditService worldEditService)
        {
            _worldEditService = worldEditService;
        }
        public Task HandleMessageAsync(string messageType, DeleteWorld message)
        {
            _worldEditService.DeletWorld(message.Id);
            return Task.CompletedTask;
        }
        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<DeleteWorld>((ReadOnlySpan<byte>)obj, (JsonSerializerOptions)null));
        }
    }
}
