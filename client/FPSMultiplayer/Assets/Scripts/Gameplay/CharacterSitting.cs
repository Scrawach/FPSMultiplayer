﻿using UnityEngine;

namespace Gameplay
{
    public class CharacterSitting : MonoBehaviour
    {
        public bool IsSitting { get; private set; }
        
        public void UpdateState(bool isSit)
        {
            IsSitting = isSit;
            // change collider or something else...
        }
    }
}