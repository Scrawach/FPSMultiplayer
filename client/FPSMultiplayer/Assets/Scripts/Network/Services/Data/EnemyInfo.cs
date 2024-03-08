using System;
using Gameplay;
using UnityEngine;

namespace Network.Services.Data
{
    public struct EnemyInfo : IDisposable
    {
        public string Id;
        public RemoteEnemy Enemy;
        public Action DisposeAction;

        public EnemyInfo(string id, RemoteEnemy enemy, Action disposeAction)
        {
            Id = id;
            Enemy = enemy;
            DisposeAction = disposeAction;
        }

        public void Dispose() => 
            DisposeAction?.Invoke();
    }
}