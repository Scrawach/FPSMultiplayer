using System;

namespace StaticData.Data
{
    [Serializable]
    public class CharacterStats
    {
        public int CurrentHealth;
        public int TotalHealth;
        public int Speed;
        public int JumpHeight;

        public CharacterStats() { }
        
        public CharacterStats(int currentHealth, int totalHealth, int speed, int jumpHeight)
        {
            CurrentHealth = currentHealth;
            TotalHealth = totalHealth;
            Speed = speed;
            JumpHeight = jumpHeight;
        }
    }
}