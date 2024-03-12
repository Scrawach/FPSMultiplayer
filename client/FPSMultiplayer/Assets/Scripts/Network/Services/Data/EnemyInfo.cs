using System;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

namespace Network.Services.Data
{
    public struct EnemyInfo : IDisposable
    {
        public string Id;
        public EnemyCharacter EnemyCharacter;
        public Action[] DisposeActions;

        public EnemyInfo(string id, EnemyCharacter enemyCharacter, Action[] disposeActions)
        {
            Id = id;
            EnemyCharacter = enemyCharacter;
            DisposeActions = disposeActions;
        }

        public void Dispose()
        {
            foreach (var disposeAction in DisposeActions) 
                disposeAction?.Invoke();
        }
    }
}