using Colyseus;
using Network.Schemas;
using Network.Services.Listeners;

namespace Network.Services.Messages
{
    public abstract class MessageHandler<TMessage> : INetworkRoomHandler
    {
        protected string MessageName { get; }

        protected MessageHandler(string messageName) => 
            MessageName = messageName;

        protected abstract void OnReceived(TMessage message);
        
        public void Handle(ColyseusRoom<State> room) => 
            room.OnMessage<TMessage>(MessageName, OnReceived);

        public void Dispose() { }
    }
}