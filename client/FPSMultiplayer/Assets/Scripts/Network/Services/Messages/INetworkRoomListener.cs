using Colyseus;
using Network.Schemas;

namespace Network.Services.Messages
{
    public interface INetworkRoomListener
    {
        void Listen(ColyseusRoom<State> room);
    }
}