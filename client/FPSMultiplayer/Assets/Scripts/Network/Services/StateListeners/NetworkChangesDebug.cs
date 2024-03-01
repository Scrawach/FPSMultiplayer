using Network.Schemas;
using UnityEngine;

namespace Network.Services.StateListeners
{
    public class NetworkChangesDebug : INetworkStateListener
    {
        public void ChangeState(State state, bool isFirstState) => 
            Debug.Log($"State changed!");
    }
}