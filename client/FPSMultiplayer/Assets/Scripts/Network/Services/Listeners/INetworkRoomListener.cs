using System;
using Colyseus;
using Network.Schemas;

namespace Network.Services.Listeners
{
    public interface INetworkRoomListener : IDisposable
    {
        void Listen(ColyseusRoom<State> room);
    }
}