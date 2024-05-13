using NetCord.Gateway;
using NetCord.Hosting.Gateway;

namespace NetCordTemplate.Handlers
{
    [GatewayEvent(nameof(GatewayClient.MessageCreate))]
    internal class MessageCreateHandler(GatewayClient client, IServiceProvider services): IGatewayEventHandler<Message>
    {
        public ValueTask HandleAsync(Message message)
        {
            return default;
        }
    }
}
