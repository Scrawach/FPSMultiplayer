using System;
using Gameplay;
using UnityEngine;

namespace Network.Services.Data
{
    public struct EnemyInfo : IDisposable
    {
        public string Id;
        public EnemyCharacter EnemyCharacter;
        public Action DisposeAction;

        public EnemyInfo(string id, EnemyCharacter enemyCharacter, Action disposeAction)
        {
            Id = id;
            EnemyCharacter = enemyCharacter;
            DisposeAction = disposeAction;
        }

        public void Dispose() => 
            DisposeAction?.Invoke();
    }
}