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
                Speed = data.speed,
                JumpHeight = data.jumpHeight
            };
        }
    }
}