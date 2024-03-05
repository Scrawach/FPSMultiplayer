using System;
using Network.Schemas;
using UnityEngine;

namespace Network.Services
{
    public struct NetworkGameObject
    {
        public Player State;
        public GameObject Instance;
        public Action Dispose;

        public NetworkGameObject(Player state, GameObject instance, Action dispose = null)
        {
            State = state;
            Instance = instance;
            Dispose = dispose;
        }
    }
}