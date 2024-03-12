using Network.Schemas;
using StaticData.Data;

namespace Extensions
{
    public static class CharacterStatsDataExtensions
    {
        public static CharacterStats ToStats(this CharacterStatsData data)
        {
            return new()
            {
                CurrentHealth = data.currentHealth,
                TotalHealth = data.totalHealth,
                Speed = data.speed,
                JumpHeight = data.jumpHeight
            };
        }
    }
}