using Schemas;
using UnityEngine;

namespace Network.Services.StateListeners
{
    public class DebugChangeState : INetworkStateListener
    {
        public void ChangeState(State state, bool isFirstState) => 
            Debug.Log($"State changed!");
    }
}