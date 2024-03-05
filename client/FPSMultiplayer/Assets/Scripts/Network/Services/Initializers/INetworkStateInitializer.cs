using System;
using Network.Schemas;

namespace Network.Services.Initializers
{
    public interface INetworkStateInitializer : IDisposable
    {
        void Initialize(State state);
    }
}