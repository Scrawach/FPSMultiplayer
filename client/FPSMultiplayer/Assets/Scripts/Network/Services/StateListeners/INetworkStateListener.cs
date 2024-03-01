using Network.Schemas;

namespace Network.Services.StateListeners
{
    public interface INetworkStateListener
    {
        void ChangeState(State state, bool isFirstState);
    }
}