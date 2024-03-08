using Colyseus;
using Network.Schemas;

namespace Network.Services.Messages
{
    public abstract class MessageListener<TMessage> : INetworkRoomListener
    {
        protected string MessageName { get; }

        protected MessageListener(string messageName) => 
            MessageName = messageName;

        protected abstract void OnReceived(TMessage message);
        
        public void Listen(ColyseusRoom<State> room) => 
            room.OnMessage<TMessage>(MessageName, OnReceived);
    }
}