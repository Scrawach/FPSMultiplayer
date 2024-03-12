using System;

namespace StaticData.Data
{
    [Serializable]
    public class GunSettings
    {
        public GunType Type;
        public int Damage;
        public float RateOfFireInSeconds;
    }
}