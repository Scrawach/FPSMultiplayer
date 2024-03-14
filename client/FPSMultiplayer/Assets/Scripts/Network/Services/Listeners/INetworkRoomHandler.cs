using System;
using Colyseus;
using Network.Schemas;

namespace Network.Services.Listeners
{
    public interface INetworkRoomHandler : IDisposable
    {
        void Handle(ColyseusRoom<State> room);
    }
}